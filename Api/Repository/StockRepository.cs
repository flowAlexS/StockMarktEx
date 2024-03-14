using Api.Data;
using Api.DTOs.Stock;
using Api.Helpers;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        => this._context = context;

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> DeletAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);

            if (stockModel is null)
            {
                return null;
            }

            this._context.Stocks.Remove(stockModel);
            await this._context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks = this._context.Stocks.Include(c => c.Comments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }

            if (!string.IsNullOrEmpty(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }

            return await stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        => await this._context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);

        public async Task<bool> StockExists(int id)
        => await this._context.Stocks.AnyAsync(x => x.Id.Equals(id));

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto)
        {
            var existingStock = await this._context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
            
            if (existingStock is null)
            {
                return null;
            }

            existingStock.Symbol = updateStockRequestDto.Symbol;
            existingStock.CompanyName = updateStockRequestDto.CompanyName;
            existingStock.Purchase = updateStockRequestDto.Purchase;
            existingStock.LastDiv = updateStockRequestDto.LastDiv;
            existingStock.Industry = updateStockRequestDto.Industry;
            existingStock.MarketCap = updateStockRequestDto.MarketCap;

            await this._context.SaveChangesAsync();
            return existingStock;
        }
    }
}

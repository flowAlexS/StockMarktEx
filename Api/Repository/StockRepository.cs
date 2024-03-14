using Api.Data;
using Api.DTOs.Stock;
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

        public Task<Stock> CreateAsync(Stock stockModel)
        {
            throw new NotImplementedException();
        }

        public Task<Stock?> DeletAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Stock>> GetAllAsync()
        => this._context.Stocks.ToListAsync();

        public Task<Stock?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}

using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class PortofolioRepository : IPortofolioRepository
    {
        private readonly ApplicationDbContext _context;

        public PortofolioRepository(ApplicationDbContext context)
        => this._context = context;

        public async Task<Portofolio> CreatePortofolioAsync(Portofolio portofolio)
        {
            await _context.AddAsync(portofolio);
            await _context.SaveChangesAsync();
            return portofolio;
        }

        public async Task<List<Stock>> GetUserPortofolio(AppUser user)
        => await this._context.Portofolios.Where(u => u.AppUserId == user.Id)
            .Select(stock => new Stock()
            {
                Id = stock.StockId,
                Symbol = stock.Stock.Symbol,
                CompanyName = stock.Stock.CompanyName,
                Purchase = stock.Stock.Purchase,
                LastDiv = stock.Stock.LastDiv,
                Industry = stock.Stock.Industry,
                MarketCap = stock.Stock.MarketCap,
            }).ToListAsync();
    }
}

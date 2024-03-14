using Api.Data;
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

        public Task<List<Stock>> GetAllAsync()
        => this._context.Stocks.ToListAsync();
    }
}

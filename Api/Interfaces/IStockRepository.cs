namespace Api.Interfaces
{
    using Api.DTOs.Stock;
    using Api.Helpers;
    using Api.Models;

    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);

        Task<Stock?> GetByIdAsync(int id);

        Task<Stock?> GetBySymbol(string symbol);

        Task<Stock> CreateAsync(Stock stockModel);

        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto);

        Task<Stock?> DeletAsync(int id);

        Task<bool> StockExists(int id);
    }
}

namespace Api.Interfaces
{
    using Api.DTOs.Stock;
    using Api.Models;

    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();

        Task<Stock?> GetByIdAsync(int id);

        Task<Stock> CreateAsync(Stock stockModel);

        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto);

        Task<Stock?> DeletAsync(int id);

        Task<bool> StockExists(int id);
    }
}

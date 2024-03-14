namespace Api.Interfaces
{
    using Api.Models;

    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();

    }
}

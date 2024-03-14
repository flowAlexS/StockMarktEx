using Api.DTOs.Stock;
using Api.Models;

namespace Api.Mappers
{
    public static class StockMapper
    {
        public static StockDto ToStockDto(this Stock stockModel)
        => new ()
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap,
            Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList(),
        };

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockRequestDto)
        => new()
        {
            Symbol = stockRequestDto.Symbol,
            CompanyName = stockRequestDto.CompanyName,
            Purchase = stockRequestDto.Purchase,
            LastDiv = stockRequestDto.LastDiv,
            Industry = stockRequestDto.Industry,
            MarketCap = stockRequestDto.MarketCap
        };
    }
}

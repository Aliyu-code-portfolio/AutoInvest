using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;

namespace AutoInvest.Application.Abstraction
{
    public interface ISaleService
    {
        Task<IEnumerable<SalesResponseDto>> GetAllSales();
        Task<SalesResponseDto> GetSalesById(string saleId);
        Task<SalesResponseDto> CreateSaleAsync(string shopId, SaleRequestDto saleRequestDto);
        Task UpdateSale(SalesResponseDto saleResponseDto);


        //I think a sale update is required because the shop that sells the vehicle may be opened for a 
        // part payment plan until delivery is done before the balance is made.


        // I am not sure if a delete sale service interface is required because if a shop succesfully
        // sells an item to a buyer, there is no refund plan and a record needs to be kept. I stand to be advised.
    }
}

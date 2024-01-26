using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;
using System.Collections;

namespace AutoInvest.Application.Abstraction
{
    public interface ISaleService
    {
        Task<StandardResponse<IEnumerable<SalesResponseDto>>> GetAllSales();
        Task<StandardResponse<SalesResponseDto>> GetSalesById(string saleId);
        Task<StandardResponse<SalesResponseDto>> CreateSaleAsync(string shopId, SaleRequestDto saleRequestDto);
        Task <StandardResponse<string>> UpdateSale(string salesId, SaleRequestDto saleRequestDto);


        
    }
}

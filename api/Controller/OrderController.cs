using api.ActionFilter;
using api.Dto;
using api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Interface;

namespace api.Controller;

public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ResponseHelper _response;

    public OrderController(IOrderService orderService, ResponseHelper response)
    {
        _orderService = orderService;
        _response = response;
    }
        
    #region GET
    [HttpGet]  
    [Route("/api/dashboard/sales")]
    public async Task<ResponseDto> GetDashboardSalesDataAsync()
    {
        var articles =
            await _orderService.GetDashboardSalesDataAsync();
        return _response.CreateResponse(HttpContext, StatusCodeType.Success, "Successfully fetched all sales", articles);
    }
    #endregion
    
    
}
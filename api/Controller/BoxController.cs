using api.Dto;
using api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Interface;

namespace api.Controller;

public class BoxController : ControllerBase
{
    private readonly IBoxService _boxService;
    private readonly ResponseHelper _response;

    public BoxController(IBoxService boxService, ResponseHelper response)
    {
        _boxService = boxService;
        _response = response;
    }
        
    #region GET
    [HttpGet]  
    [Route("/api/boxes")]
    public async Task<ResponseDto> GetAllBoxesAsync()
    {
        var articles =
            await _boxService.GetAllBoxesAsync();
        return _response.CreateResponse(HttpContext, StatusCodeType.Success, "Successfully fetched all boxes", articles);
    }
    #endregion
    
}
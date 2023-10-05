using api.ActionFilter;
using api.Dto;
using api.Dto.Box;
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
    
    [HttpGet]  
    [Route("/api/boxes/{boxId}")]
    public async Task<ResponseDto> GetAllBoxByIdAsync([FromRoute] int boxId)
    {
        var articles =
            await _boxService.GetBoxByIdAsync(boxId);
        return _response.CreateResponse(HttpContext, StatusCodeType.Success, "Successfully fetched box", articles);
    }

    #region POST
    // It should be possible to create a new article
    [HttpPost]
    [ValidateModelFilter]
    [Route("/api/boxes")]
    public async Task<ResponseDto> CreateBoxAsync([FromBody] PostBoxDto boxRequest)
    {
        return _response.CreateResponse(
            HttpContext, StatusCodeType.Created, 
            $"Successfully create box with title: {boxRequest.Title}",
            await _boxService.CreateBoxAsync(
                boxRequest.Title,
                boxRequest.Type,
                boxRequest.Image,
                boxRequest.Status,
                boxRequest.Price,
                boxRequest.Color,
                boxRequest.Description));
    }
    #endregion
    
    #region PUT
    [HttpPut]
    [ValidateModelFilter]
    [Route("/api/boxes/{boxId}")]
    public async Task<ResponseDto> UpdateBoxByIdAsync(int boxId,[FromBody] PutBoxDto boxRequest)
    {
        var result = await _boxService.UpdateBoxByIdAsync(boxId,boxRequest.Title,boxRequest.Type,boxRequest.Image,boxRequest.Status,boxRequest.Price,boxRequest.Color,boxRequest.Description);
        return _response.CreateResponse(HttpContext, StatusCodeType.Success, $"Box with ID: {boxId} was updated", result);   
    }
    #endregion
    
    #region DELETE
    [HttpDelete]
    [Route("/api/boxes/{boxId}")]
    public async Task<ResponseDto> DeleteBoxByIdAsync([FromRoute] int boxId)
    {
        var result = await _boxService.DeleteBoxByIdAsync(boxId);
        return _response.CreateResponse(HttpContext, StatusCodeType.Created, $"Box with: {boxId} was deleted", result);
    }
    #endregion
}
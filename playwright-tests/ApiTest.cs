using System.Text.Json;
using api.Dto.Box;
using FluentAssertions;
using Infrastructure.DataModel;
using Microsoft.Playwright;

namespace playwright_tests;

public class ResponseData
{
    public string messageToClient { get; set; }
    public Box responseData { get; set; }
}

public class ResponseDataEmpty
{
    public string messageToClient { get; set; }
    public bool responseData { get; set; }
}


public class ApiTest
{
    private IAPIRequestContext _context;
    
    private int _boxId;

    [SetUp]
    public async Task Setup()
    {
        _context = await new ContextConfig().SetContext();
    }

    [Test, Order(1)]
    public async Task CreateBoxSuccess()
    {
        var testBox = new PostBoxDto()
        {
            Title = "Test BOX API",
            Type = "Squared",
            Image = "https://www.google.com",
            Color = "Red",
            Status = "New",
            Description = "Test Box",
            Price = 100
        };
        
        var options = new APIRequestContextOptions
        {
            DataObject = testBox
        };
        
        var response = await _context.PostAsync("api/boxes", options);

        var jsonString = await response.JsonAsync();
        
        // Deserialize the response
        var responseData = jsonString?.Deserialize<ResponseData>(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive  = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        responseData.Should().NotBe(null);
        
        responseData?.responseData.Title.Should().Be(testBox.Title);
        responseData?.responseData.Type.Should().Be(testBox.Type);
        responseData?.responseData.Image.Should().Be(testBox.Image);
        responseData?.responseData.Color.Should().Be(testBox.Color);
        responseData?.responseData.Status.Should().Be(testBox.Status);
        responseData?.responseData.Description.Should().Be(testBox.Description);
        responseData?.responseData.Price.Should().Be(testBox.Price);
        
        _boxId = responseData?.responseData.Id ?? 0;
        responseData?.messageToClient.Should().Be($"Successfully create box with title: {testBox.Title}");
        response.Ok.Should().BeTrue();
    }
    
    [Test, Order(2)]
    public async Task GetBoxById()
    {

        var response = await _context.GetAsync($"api/boxes/{_boxId}");

        var data = await response.JsonAsync();
        var responseData = data?.Deserialize<ResponseData>(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive  = true,
            
        });
        
        response.Ok.Should().BeTrue();
        responseData?.responseData.Should().NotBeNull();
        responseData?.responseData.Id.Should().Be(_boxId);
        responseData?.messageToClient.Should().Be($"Successfully fetched box");
    }
    
    
    [Test, Order(3)]
    public async Task UpdateBoxById()
    {
        var updatedBox = new PostBoxDto()
        {
            Title = "UPDATE Test BOX API",
            Type = "Squared Box Updated",
            Image = "https://www.google.com",
            Color = "Red",
            Status = "Old",
            Description = "Test Box",
            Price = 300
        };
        
        var options = new APIRequestContextOptions
        {
            DataObject = updatedBox
        };
        
        var response = await _context.PutAsync($"api/boxes/{_boxId}", options);
        var jsonString = await response.JsonAsync();
        
        var responseData = jsonString?.Deserialize<ResponseData>(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive  = true,
            
        });
         

        responseData.Should().NotBe(null);
         
        responseData?.responseData.Title.Should().Be(updatedBox.Title);
        responseData?.responseData.Type.Should().Be(updatedBox.Type);
        responseData?.responseData.Image.Should().Be(updatedBox.Image);
        responseData?.responseData.Color.Should().Be(updatedBox.Color);
        responseData?.responseData.Status.Should().Be(updatedBox.Status);
        responseData?.responseData.Description.Should().Be(updatedBox.Description);
        responseData?.responseData.Price.Should().Be(updatedBox.Price);
        
        _boxId = responseData?.responseData.Id ?? 0;
        responseData?.messageToClient.Should().Be($"Box with ID: {_boxId} was updated");
        response.Ok.Should().BeTrue();
        
    }
    
    [Test, Order(3)]
    public async Task DeleteBoxById()
    {
        var response = await _context.DeleteAsync($"api/boxes/{_boxId}");
        
        var jsonString = await response.JsonAsync();
        
        var responseData = jsonString?.Deserialize<ResponseDataEmpty>(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive  = true,
            
        });
        
        responseData?.messageToClient.Should().Be($"Box with: {_boxId} was deleted");
     
    }
   
}

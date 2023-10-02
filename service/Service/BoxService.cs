using Infrastructure.DataModel;
using Infrastructure.QueryModel;
using Infrastructure.Repository.Interface;
using Service.Service.Interface;

namespace Service.Service;

public class BoxService : IBoxService
{
    private readonly IBoxRepository _boxRepository;

    public BoxService(IBoxRepository boxRepository)
    {
        _boxRepository = boxRepository;
    }
    
    public async Task<IEnumerable<BoxModelQuery>> GetAllBoxesAsync()
    {
        return await _boxRepository.GetAllBoxesAsync();
    }
    
    public async Task<Box> GetBoxByIdAsync(int boxId)
    {
        return await _boxRepository.GetBoxByIdAsync(boxId);
    }

    public async Task<Box> UpdateBoxByIdAsync(int id, string title, string type, string image, string status, decimal price, string color,
        string description)
    {
        return await _boxRepository.UpdateBoxByIdAsync(id, title, type, image, status, price, color, description);
    }

    public async Task<Box> CreateBoxAsync(string title, string type, string image, string status, decimal price, string color,
        string description)
    {
        return await _boxRepository.CreateBoxAsync(title, type, image, status, price, color, description);
    }

    public async Task<bool> DeleteBoxByIdAsync(int id)
    {
        return await _boxRepository.DeleteBoxByIdAsync(id);
    }

   
}
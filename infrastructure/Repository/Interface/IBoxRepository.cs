using Infrastructure.DataModel;
using Infrastructure.QueryModel;

namespace Infrastructure.Repository.Interface;

public interface IBoxRepository
{
    Task<IEnumerable<BoxModelQuery>> GetAllBoxesAsync();
    Task<bool> DeleteBoxByIdAsync(int id);
    Task<Box> GetBoxByIdAsync(int boxId);
    Task<Box> UpdateBoxByIdAsync(int id, string title, string type, string image, string status, decimal price, string color, string description);
    Task<Box> CreateBoxAsync(string title, string type, string image, string status, decimal price, string color, string description);
}
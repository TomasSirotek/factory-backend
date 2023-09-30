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
        return await _boxRepository.GetAllArticlesForFeed();
    }

    public Task<Box> GetArticleById(int articleId)
    {
        throw new NotImplementedException();
    }

    public Task<Box> CreateArticle(string articleRequestHeadline, string articleRequestAuthor, string articleRequestArticleImgUrl,
        string articleRequestBody)
    {
        throw new NotImplementedException();
    }

    public Task<Box> UpdateArticle(int articleDtoArticleId, string articleDtoHeadline, string articleDtoAuthor,
        string articleDtoArticleImgUrl, string articleDtoBody)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteArticleById(int articleId)
    {
        throw new NotImplementedException();
    }
}
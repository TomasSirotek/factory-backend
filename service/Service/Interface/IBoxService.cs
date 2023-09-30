using Infrastructure.DataModel;
using Infrastructure.QueryModel;

namespace Service.Service.Interface;

public interface IBoxService
{
    Task<IEnumerable<BoxModelQuery>> GetAllBoxesAsync();
    Task<Box> GetArticleById(int articleId);
    Task<Box> CreateArticle(string articleRequestHeadline, string articleRequestAuthor, string articleRequestArticleImgUrl, string articleRequestBody);
    Task<Box> UpdateArticle(int articleDtoArticleId, string articleDtoHeadline, string articleDtoAuthor, string articleDtoArticleImgUrl, string articleDtoBody);
    Task<bool> DeleteArticleById(int articleId);
}
using Infrastructure.DataModel;
using Infrastructure.QueryModel;

namespace Infrastructure.Repository.Interface;

public interface IBoxRepository
{
    Task<IEnumerable<BoxModelQuery>> GetAllArticlesForFeed();
    Task<Box> GetArticleById(int articleId);
    Task<Box> CreateArticle(string headline, string author, string articleImgUrl, string articleBody);
    Task<Box> UpdateArticle(int articleDtoArticleId, string articleDtoHeadline, string articleDtoAuthor, string articleDtoArticleImgUrl, string articleDtoBody);
    Task<bool> DeleteArticleById(int articleId);
}
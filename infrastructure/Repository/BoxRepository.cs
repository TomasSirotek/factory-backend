using Dapper;
using Infrastructure.DataModel;
using Infrastructure.QueryModel;
using Infrastructure.Repository.Interface;
using Npgsql;

namespace Infrastructure.Repository;

public class BoxRepository : IBoxRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public BoxRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    public async Task<IEnumerable<BoxModelQuery>> GetAllArticlesForFeed()
    {
        await using var connection = await _dataSource.OpenConnectionAsync();
        const string sql =
            "SELECT id,title,type,image,status,price,color,description FROM factory.box";

        return await connection.QueryAsync<BoxModelQuery>(sql);
    }

    public Task<Box> GetArticleById(int articleId)
    {
        throw new NotImplementedException();
    }

    public Task<Box> CreateArticle(string headline, string author, string articleImgUrl, string articleBody)
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
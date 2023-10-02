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
    public async Task<IEnumerable<BoxModelQuery>> GetAllBoxesAsync()
    {
        await using var connection = await _dataSource.OpenConnectionAsync();
        const string sql =
            "SELECT id,title,type,image,status,price,color,description FROM factory.box";

        return await connection.QueryAsync<BoxModelQuery>(sql);
    }
    
    public async Task<Box> GetBoxByIdAsync(int boxId)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();
        const string sql =
            "SELECT id,title,type,image,status,price,color,description FROM factory.box WHERE id = @boxId";

        return await connection.QueryFirstAsync<Box>(sql,new { boxId });
    }

    public async Task<Box> UpdateBoxByIdAsync(int id, string title, string type, string image, string status, decimal price, string color,
        string description)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();
        const string sql =
            "UPDATE factory.box SET title = @title, type = @type, image = @image, status = @status, price = @price,color = @color,description = @description WHERE id = @id RETURNING id,title,type,image,status,price,color,description ";
        
        return await connection.QueryFirstAsync<Box>(sql,
            new { id, title, type, image, status,price, color, description });
    }

    public async Task<Box> CreateBoxAsync(string title, string type, string image, string status, decimal price, string color,
        string description)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();
        const string sql =
            "INSERT INTO factory.box (title, type, image, status,price,color,description) VALUES (@title, @type, @image, @status,@price,@color,@description) RETURNING id, title, type, image,status,price,color,description ";
        
        return await connection.QueryFirstAsync<Box>(sql, new { title, type, image, status,price,color,description });
    }
    
    public async Task<bool> DeleteBoxByIdAsync(int id)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();
        const string sql = "DELETE FROM factory.box WHERE id = @id";
        
        return await connection.ExecuteAsync(sql, new { id }) > 0;
    }

   
}
using System.Text.Json;
using Dapper;
using DirectoryService.Core.Locations;
using DirectoryService.Domain.Locations;
using DirectoryService.Infrastructure.Postgres.Database;

namespace DirectoryService.Infrastructure.Postgres.Repositories;

public class NpgSqlLocationsRepository : ILocationsRepository
{
    private readonly IDbConnectionFactory _connectionFactory;
    
    private static readonly JsonSerializerOptions JsonOptions =
        new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    
    public NpgSqlLocationsRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }


    public async Task<Guid> AddAsync(Location location, CancellationToken cancellationToken)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);

        // Обязательно: Добавить транзакцию (Error, Result)
        const string locationInsertSql = """
                                         INSERT INTO locations
                                             (id, name, address, created_at, updated_at)
                                         VALUES
                                             (@id, @name, @address::jsonb, @createdAt, @updatedAt)
                                         RETURNING id;
                                         """;

        var locationInsertParams = new
        {
            id = location.Id,
            name = location.Name.Value,
            address = JsonSerializer.Serialize(location.Address, JsonOptions),
            createdAt = location.CreatedAt,
            updatedAt = location.UpdatedAt,
        };

        await connection.ExecuteAsync(new CommandDefinition(locationInsertSql, locationInsertParams, 
            cancellationToken: cancellationToken));
        
        return location.Id;
    }

    public async Task<bool> NameIsUniqueAsync(string name, CancellationToken cancellationToken)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);

        var locationSelectSql = """
                                SELECT EXISTS (
                                    SELECT 1
                                    FROM locations
                                    WHERE name = @Name
                                );
                                """;

        var exists = await connection.ExecuteScalarAsync<bool>(new CommandDefinition(
            locationSelectSql, new {Name = name}, cancellationToken: cancellationToken));
        
        return !exists;
    }
}
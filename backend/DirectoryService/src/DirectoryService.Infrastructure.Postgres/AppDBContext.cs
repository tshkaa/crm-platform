using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Infrastructure.Postgres;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }
}
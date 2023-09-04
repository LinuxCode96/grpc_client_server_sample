
using grpc_server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace grpc_server.Data;

public class ServerDbContext : DbContext
{
    public DbSet<DbPerson> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=data.db");
    }
}

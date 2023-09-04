
namespace grpc_server.Data.Models;

public class DbPerson
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
}

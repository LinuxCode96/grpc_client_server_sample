
using Grpc.Core;
using grpc_server.Data;
using static PeopleService;

namespace grpc_server.Services;

public class PeopleServiceImpl: PeopleServiceBase
{
    public override async Task<Person> CreatePerson(
        CreatePersonRequest request,
        ServerCallContext context)
    {
        using var ctx = new ServerDbContext();

        var pers = new Data.Models.DbPerson
        {
            LastName = request.LastName,
            Name=request.FirstName,
        };

        await ctx.Persons.AddAsync(pers);

        await ctx.SaveChangesAsync();

        return new Person
        {
            LastName= request.LastName,
            FirstName= request.FirstName,
            Id=pers.Id
        };
    }
}

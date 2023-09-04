
using Grpc.Core;
using static HelloService;

namespace grpc_server.Services;

public class HelloServiceImpl : HelloServiceBase
{
    public override Task<HelloResponse> Welcome(
        Hellorequest request,
        ServerCallContext context)
    {
        var message = $"Hello {request.FirstName} {request.LastName}!";
        return Task.FromResult( new HelloResponse { Message = message }); 
    }
}

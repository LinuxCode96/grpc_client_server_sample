using Grpc.Core;
using grpc_server.Data;
using grpc_server.Services;

//Data base creation
await new ServerDbContext().Database.EnsureCreatedAsync();

// Grpc Services
Server server = new Server()
{
    Ports = { new ServerPort("localhost", 5099, ServerCredentials.Insecure) },
    Services = { HelloService.BindService(new HelloServiceImpl()) }
};

//Server server = new Server()
//{
//Ports = { new ServerPort("localhost", 5099, ServerCredentials.Insecure) },
//Services = { PeopleService.BindService(new PeopleServiceImpl()) }
//Services = { PeopleService.BindService(new PeopleServiceImpl()) }
//};

try
{
    server.Start();
    Console.WriteLine("Press enter to close the server");

    Console.ReadLine();
}
catch(Exception ex)
{
    Console.WriteLine("An error has been thrown : " + ex.ToString());
}
finally
{
    if (server is not null)
    {
       await server.ShutdownAsync();
    }
}
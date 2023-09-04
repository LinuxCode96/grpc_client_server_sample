﻿using Grpc.Core;

Server server = new Server()
{
    Ports = { new ServerPort("localhost", 7777, ServerCredentials.Insecure) },
    Services = { }
};

try
{
    server.Start();
    Console.WriteLine("Server is listening to port 7777");
    Console.ReadLine();
}
catch(Exception ex)
{
    Console.WriteLine("An error has been thrown : " + ex);
}
finally
{
    if (server is not null)
    {
       await server.ShutdownAsync();
    }
}
using Grpc.Core;

Channel channel = new Channel("localhost:7777", ChannelCredentials.Insecure);

try
{
   await channel.ConnectAsync();
   Console.WriteLine("The client connected successfully  to the server");

    var client = new HelloService.HelloServiceClient(channel);
    var response = await client.WelcomeAsync(new Hellorequest {
        FirstName="Linux",
        LastName="2000" 
    });
    
    Console.WriteLine(response.Message);
    Console.ReadLine();
}
catch(Exception ex)
{
    Console.WriteLine("An error has been thrown : " + ex);
}
finally
{
    if(channel != null)
    {
        await channel.ShutdownAsync();
    }
}

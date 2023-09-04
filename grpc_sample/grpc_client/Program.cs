using Grpc.Core;

Channel channel = new Channel("localhost:5099", ChannelCredentials.Insecure);

try
{
   await channel.ConnectAsync();
   Console.WriteLine("Successfully connected  to the server !");

    var client = new HelloService.HelloServiceClient(channel);

    var request = new Hellorequest
    {
        FirstName="Linux",
        LastName="2000",
    };
    request.Children.AddRange(new[]
    {
        new Child {FirstName="Lux"},
        new Child {FirstName="Chloé"}
    });

    var response = await client.WelcomeAsync(request);

    Console.WriteLine(response.Message);

    //Console.WriteLine("First name?");
    //var name = Console.ReadLine();

    //Console.WriteLine("Last name? ");
    //var lastName = Console.ReadLine();

    //var request = new CreatePersonRequest
    //{
    //    FirstName= name,
    //    LastName= lastName
    //};

    //var client = new PeopleService.PeopleServiceClient(channel);

    //var response = await client.CreatePersonAsync(request); 



    //Console.WriteLine($"{response.FirstName} {response.LastName} has been created" + $"on the server! (id={response.Id})");
    Console.ReadLine();
}
catch(Exception ex)
{
    Console.WriteLine("An error occured : " + ex);
}
finally
{
    if(channel != null)
    {
        await channel.ShutdownAsync();
    }
}

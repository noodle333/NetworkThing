using System;
using System.Text.Json;
using RestSharp;


RestClient pokeClient = new RestClient("https://pokeapi.co/api/v2");
while (true)
{
    Console.WriteLine("Which pokemon?");
    RestRequest request;
    request = GetUserInput();
    RestResponse response = await pokeClient.GetAsync(request);

    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
    {
        Console.WriteLine("Not found!");
    }
    else
    {
        Pokemon poke = JsonSerializer.Deserialize<Pokemon>(response.Content);
        Console.WriteLine($"Name: {poke.Name}   id: {poke.Id}");
    }
}

static RestRequest GetUserInput()
{
    string userInput = Console.ReadLine();

    RestRequest request = new RestRequest($"pokemon/{userInput}");

    return request;
}



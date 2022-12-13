using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

using shared.Model;

namespace blazor_mrmythical.Data;

public class ApiService
{
    private readonly HttpClient http;
    private readonly IConfiguration configuration;
    private readonly string baseAPI = "";

    public ApiService(HttpClient http, IConfiguration configuration)
    {
        this.http = http;
        this.configuration = configuration;
        this.baseAPI = configuration["base_api"];
    }

    public async Task<GameClass[]?> GetGameClasses()
    {
        string url = $"{baseAPI}healing/";
        return await http.GetFromJsonAsync<GameClass[]>(url);
    }

    public async Task<Player> CreatePlayer(string playerName, int gameClassId)
    {
        string url = $"{baseAPI}player/";
        Player_DTO create = new(playerName, gameClassId);
        HttpResponseMessage res = await http.PostAsJsonAsync<Player_DTO>(url, create);
        string json = res.Content.ReadAsStringAsync().Result;
        Player? newPlayer = JsonSerializer.Deserialize<Player>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Ignore case when matching JSON properties to C# properties
            }
        );
        return newPlayer;
    }
}

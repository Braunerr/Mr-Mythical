using System.Net.Http.Json;
using System.Text.Json;
using System.Net;
using Microsoft.Extensions.Configuration;

using shared.Model;
using Services.Dungeons;

namespace blazor_mrmythical.Data;

public class ApiService
{
    public string errorMessage;

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

    public async Task<BestDungeons?> GetCharacterBest(string region, string realm, string name)
    {
        string url =
            $"https://raider.io/api/v1/characters/profile?region={region}&realm={realm}&name={name}&fields=mythic_plus_best_runs";
        try
        {
            var response = await http.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BestDungeons>();
        }
        catch
        {
            return null;
        }
    }

    public async Task<AlternateDungeons?> GetCharacterAlternate(
        string region,
        string realm,
        string name
    )
    {
        string url =
            $"https://raider.io/api/v1/characters/profile?region={region}&realm={realm}&name={name}&fields=mythic_plus_alternate_runs";
        try
        {
            var response = await http.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AlternateDungeons>();
        }
        catch
        {
            return null;
        }
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
        return newPlayer!;
    }
}

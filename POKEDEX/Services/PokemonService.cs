using System.Net.Http;
using System.Threading.Tasks;

public class PokemonService
{
    private readonly HttpClient _httpClient;

    public PokemonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetPokemonAsync(string pokemonName)
    {
        try
        {
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}
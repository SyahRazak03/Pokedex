using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POKEDEX.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly PokemonService _pokemonService;

    public HomeController(PokemonService pokemonService)
    {
        _pokemonService = pokemonService ?? throw new ArgumentNullException(nameof(pokemonService));
    }

    public async Task<IActionResult> Index(int offset = 0, int limit = 10)
    {
        try
        {
            var pokemons = new List<Pokemon>();
            var responseJson = await _pokemonService.GetPokemonAsync($"?limit={limit}&offset={offset}");
            if (string.IsNullOrEmpty(responseJson) || responseJson.StartsWith("Error:"))
            {
                ViewBag.Error = "Unable to load Pokémon list. Please try again later.";
                return View(pokemons);
            }

            var pokemonList = JsonConvert.DeserializeObject<PokemonList>(responseJson);
            if (pokemonList.Results.Count == 0)
            {
                ViewBag.Error = "No Pokémon available within the current range.";
                return View(pokemons);
            }

            foreach (var result in pokemonList.Results)
            {
                var detailJson = await _pokemonService.GetPokemonAsync(result.Name);
                if (!string.IsNullOrEmpty(detailJson) && !detailJson.StartsWith("Error:"))
                {
                    var pokemon = JsonConvert.DeserializeObject<Pokemon>(detailJson);
                    pokemons.Add(pokemon);
                }
            }

            ViewBag.NextOffset = offset + limit;
            ViewBag.HasMore = !string.IsNullOrEmpty(pokemonList.Next);
            return View(pokemons);
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"A system error occurred: {ex.Message}. Please contact support.";
            return View(new List<Pokemon>());
        }
    }

    [HttpGet]
    public IActionResult Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return RedirectToAction("Index");
        }
        return RedirectToAction("Details", new { name = query.ToLower() });
    }

    public async Task<IActionResult> Details(string name)
    {
        try
        {
            var responseJson = await _pokemonService.GetPokemonAsync(name);
            if (responseJson.StartsWith("Error:"))
            {
                ViewBag.Error = $"Could not find Pokémon '{name}'. Please check the name and try again.";
                return View(null);
            }

            var pokemon = JsonConvert.DeserializeObject<Pokemon>(responseJson);
            return View(pokemon);
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"A server error occurred while loading '{name}': {ex.Message}. Please try again later.";
            return View(null);
        }
    }

    public IActionResult About()
    {
        return View();
    }
}
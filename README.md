Pokedex Web Application
Overview
This is a Pokedex web application built using ASP.NET Core MVC. The application consumes data from the PokeAPI (https://pokeapi.co/api/v2/pokemon/) to display a list of Pokémon, their detailed information, and allows users to search and paginate through the data. The project features a Pokédex-inspired design with responsive styling and robust error handling.
Features

Home Page: Displays a grid of Pokémon with images, IDs, names, and types, with a "Load More" button for pagination.
Details Page: Shows comprehensive details for a selected Pokémon, including stats, types, abilities, moves, vitals, and held items.
Search Functionality: Allows users to search for a specific Pokémon by name.
About Us Page: Provides project background and developer information.
Responsive Design: Optimized for desktop and mobile views with CSS styling.
Error Handling: Manages API failures, invalid inputs, and empty states with user-friendly messages.

Technologies Used

Framework: ASP.NET Core MVC
Language: C#
API: PokeAPI (public third-party API)
JSON Handling: Newtonsoft.Json
Styling: CSS with custom classes in site.css
Development Environment: Visual Studio 2022

Project Structure

POKEDEX/
  POKEDEX/: Main project folder
    Controllers/: Contains HomeController.cs
    Models/: Contains Pokemon.cs, PokemonList.cs, ErrorViewModel.cs
    Services/: Contains PokemonService.cs
    Views/: Contains view files (Index.cshtml, Details.cshtml, About.cshtml, _Layout.cshtml)
      Views/Home/: Specific views for the Home controller
      Views/Shared/: Shared layout files
    wwwroot/: Static files
      wwwroot/css/: Contains site.css
      wwwroot/js/: JavaScript files (if any)
pokedex.sln: Solution file

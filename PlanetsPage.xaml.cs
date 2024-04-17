using SwapiDev.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace SwapiDev
{

	public partial class PlanetsPage : ContentPage
	{

        private string urlApiPlanet = "https://swapi.dev/api/planets";

        private readonly HttpClient _httpClient;

        public ObservableCollection<Planet> planets { get; set; } = new();

        public PlanetsPage()
		{
			InitializeComponent();
            _httpClient = new HttpClient();
            OnAppearing();
        }


        protected override async void OnAppearing()
        {

            base.OnAppearing();
            var planetsResponse = await _httpClient.GetFromJsonAsync<PlanetDetail>(urlApiPlanet);
            
            planetsResponse.results.ForEach(result => planets.Add(result));
            
        }
    }
}
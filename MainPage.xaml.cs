using Microsoft.Maui.ApplicationModel;
using SwapiDev.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;

namespace SwapiDev
{
    public partial class MainPage : ContentPage
    {
        private string urlApiPeople = "https://swapi.dev/api/people";
        private string urlApiPlanet = "https://swapi.dev/api/planets";

        private readonly HttpClient _httpClient;
  

        public ObservableCollection<People> peoples { get; set; } = new();
        public ObservableCollection<Planet> planets { get; set; } = new();
        public MainPage()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            OnAppearing();
        }

        protected override async void OnAppearing() {
        
            base.OnAppearing();
            var planetsResponse = await _httpClient.GetFromJsonAsync<PlanetDetail>(urlApiPlanet);
            var peoplesResponse = await _httpClient.GetFromJsonAsync<PeopleDetail>(urlApiPeople);
            planetsResponse.results.ForEach(result => planets.Add(result));
            peoplesResponse.results.ForEach(people => peoples.Add(people));
        }


        private void ChangeTheme(object sender, EventArgs e)
        {
            
            if (Application.Current.RequestedTheme == AppTheme.Light)
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Light;
            }
        }


    }

}

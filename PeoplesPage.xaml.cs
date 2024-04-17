using SwapiDev.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace SwapiDev
{

    public partial class PeoplesPage : ContentPage
    {


        private string urlApiPeople = "https://swapi.dev/api/people";
      

        private readonly HttpClient _httpClient;


        public ObservableCollection<People> peoples { get; set; } = new();
 

        public PeoplesPage()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            OnAppearing();
        }

        protected override async void OnAppearing()
        {

            base.OnAppearing();
           
            var peoplesResponse = await _httpClient.GetFromJsonAsync<PeopleDetail>(urlApiPeople);
         
            peoplesResponse.results.ForEach(people => peoples.Add(people));
        }

    }
}
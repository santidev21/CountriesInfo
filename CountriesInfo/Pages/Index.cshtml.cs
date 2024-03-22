using CountriesInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace CountriesInfo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Country> countriesLst = new List<Country>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            this.loadInformation(this.countriesLst);
        }

        public void loadInformation(List<Country> countriesLst)
        {
            string countriesStr = "~IN*TN>CHENNAI>MADURAI>KOVAI>ERODE*AP>ONGOLE>TENALI>VIZAG*TS>HYDERABAD>WARANGAL>VIKARABAD~USA*ALASKA>JUNEAU>SITKA>KENAI~CHINA*HAINAN>HAIKOU>SANYA>DONGFANG*HUNAN>CHANGHSA>YUEYANG>CHANGDE";

            // Regular expressions are assigned to filter.
            string countriesPattern = @"~(.*?)(?=~|$)";
            string statesPattern = @"\*[^*]+";
            string citiesPattern = @"(?<=>)[^>]+";
            string countryNamePattern = @"(?<=~)[^*]+(?=\*)";
            string stateNamePattern = @"(?<=\*)[^>*]+";

            // Countries are extracted using regular expressions and looped through.
            var countriesMatches = Regex.Matches(countriesStr, countriesPattern).ToArray();
            foreach (var currentCountry in countriesMatches)
            {
                // The country name is extracted from the string and the country object is created.
                string countryName = Regex.Match(currentCountry.Value, countryNamePattern).ToString();
                Country country = new Country(countryName);

                // States are extracted using regular expressions and looped through.
                var statesMatches = Regex.Matches(currentCountry.Value, statesPattern).ToArray();
                foreach (var currentState in statesMatches)
                {
                    // The state name is extracted from the string and the state object is created.
                    string stateName = Regex.Match(currentState.Value, stateNamePattern).ToString();
                    State state = new State(stateName);

                    // Cities are extracted using regular expressions and looped through.
                    var citiesMatches = Regex.Matches(currentState.Value, citiesPattern).ToArray();
                    foreach(var currentCity in citiesMatches)
                    {
                        // The city name is extracted from the string and the city is created.
                        string cityName = currentCity.Value;
                        City city = new City(cityName);
                        state.addCity(city);
                    }
                    country.addState(state);
                }
                countriesLst.Add(country);
            }
        }
    }
}

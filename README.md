# CountriesInfo

This program consists of solving a proposed exercise which consists of a string that contains information about countries, states and cities, separated by characters as shown below:
```csharp
string countriesStr = "~IN*TN>CHENNAI>MADURAI>KOVAI>ERODE*AP>ONGOLE>TENALI>VIZAG*TS>HYDERABAD>WARANGAL>VIKARABAD~USA*ALASKA>JUNEAU>SITKA>KENAI~CHINA*HAINAN>HAIKOU>SANYA>DONGFANG*HUNAN>CHANGHSA>YUEYANG>CHANGDE";
```
The characters are denoted as follows:
- \~ denotes country
- \* denotes State
- \> denotes city

In this solution I chose to split the string using regular expressions to separate the countries, then the states, and finally the cities:
```csharp
    // Regular expressions are assigned to filter.
    string countriesPattern = @"~(.*?)(?=~|$)";
    string statesPattern = @"\*[^*]+";
    string citiesPattern = @"(?<=>)[^>]+";
    string countryNamePattern = @"(?<=~)[^*]+(?=\*)";
    string stateNamePattern = @"(?<=\*)[^>*]+";
```

By correctly separating the information, work using object-oriented programming where the classes are the following:
```csharp
    public class City
    {
        public string Name { get; }
        public City(string name)
        {
            Name = name;
        }
    }

    public class State
    {
        public string Name { get; }
        public List<City> Cities { get; }

        public State(string name)
        {
            Cities = new List<City>();
            Name = name;
        }

        public void addCity(City city)
        {
            Cities.Add(city);
        }
    }

    public class Country
    {
        public string Name { get; }
        public List<State> States { get; }

        public Country(string name)
        {
            States = new List<State>();
            Name = name;

        } 

        public void addState(State state)
        {
            States.Add(state);
        }
    }
```

With these models the information was filled (Please go to the [Index.cshtml.cs](CountriesInfo/Pages/Index.cshtml.cs) file, line 35) and at the end a list of countries was obtained, with which the dropdowns were populated.

Finally, the enabled and disabled state of the dropdown was taken into consideration to prevent the user from trying to access, for example, a city without selecting the country and state first (If you want more details on this operation, go to the [Index.cshtml](CountriesInfo/Pages/Index.cshtml), starting from the line 60 and 94).

namespace CountriesInfo.Models
{
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
}

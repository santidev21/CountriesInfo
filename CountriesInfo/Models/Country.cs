namespace CountriesInfo.Models
{
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
}

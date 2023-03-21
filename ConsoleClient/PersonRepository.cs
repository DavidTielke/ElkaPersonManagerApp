namespace PersonManagerApp.ConsoleClient;

internal class PersonRepository
{
    private readonly PersonParser _personParser;

    public PersonRepository()
    {
        _personParser = new PersonParser();
    }

    public List<Person> Load()
    {
        var lines = File.ReadAllLines("data.csv");
        var persons = _personParser.Parse(lines);
        return persons;
    }
}
namespace PersonManagerApp.ConsoleClient;

public class PersonRepository
{
    private readonly PersonParser _personParser;

    public PersonRepository()
    {
        _personParser = new PersonParser();
    }

    public void Insert(Person person)
    {
        if (person == null)
        {
            throw new ArgumentNullException(nameof(person), "person cant be null");
        }

        var personHasId = person.Id > 0;
        if (!personHasId)
        {
            throw new InvalidOperationException($"Cant add person with id {person.Id}");
        }

        var dataIsValid = person.Id > 0 && !string.IsNullOrWhiteSpace(person.Name) && person.Age >= 0;
        if (!dataIsValid)
        {
            throw new FormatException("One or more data field is person arenot valid");
        }

        var persons = Load();
        var idDotExist = persons.All(p => p.Id != person.Id);
        if (!idDotExist)
        {
            throw new InvalidOperationException("Can't add person with an already existing id to the store");
        }

        var stringData = $"{person.Id},{person.Name},{person.Age}";
        File.AppendAllLines("data.csv", new[] { stringData });
    }

    public List<Person> Load()
    {
        var lines = File.ReadAllLines("data.csv");
        var persons = _personParser.Parse(lines);
        return persons;
    }
}
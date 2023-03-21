namespace PersonManagerApp.ConsoleClient;

public class PersonParser
{
    public List<Person> Parse(string[] lines)
    {
        var persons = lines.Select(l => l.Split(","))
            .Select(p => new Person
            {
                Id = int.Parse(p[0]) + 1,
                Name = p[1],
                Age = int.Parse(p[2])
            })
            .ToList();
        return persons;
    }
}
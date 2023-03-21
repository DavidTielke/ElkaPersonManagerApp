namespace PersonManagerApp.ConsoleClient;

internal class PersonParser
{
    public List<Person> Parse(string[] lines)
    {
        var persons = lines.Select(l => l.Split(","))
            .Select(p => new Person
            {
                Id = int.Parse(p[0]),
                Name = p[1],
                Age = int.Parse(p[2])
            })
            .ToList();
        return persons;
    }
}
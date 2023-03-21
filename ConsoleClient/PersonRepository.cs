namespace PersonManagerApp.ConsoleClient;

internal class PersonRepository
{
    public List<Person> Load()
    {
        return File
            .ReadAllLines("data.csv")
            .Select(l => l.Split(","))
            .Select(p => new Person
            {
                Id = int.Parse(p[0]),
                Name = p[1],
                Age = int.Parse(p[2])
            })
            .ToList();
    }
}
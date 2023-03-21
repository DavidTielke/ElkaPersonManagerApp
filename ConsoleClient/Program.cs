namespace PersonManagerApp.ConsoleClient;

internal class Program
{
    public static void Main(string[] args)
    {
        var manager = new PersonManager();

        var adults = manager.GetAllAdults();
        var children = manager.GetAllChildren();

        PrintPersonList(adults, "Erwachsene");
        PrintPersonList(children, "Kinder");
    }

    private static void PrintPersonList(List<Person> person, string title)
    {
        Console.WriteLine($"## {title} ({person.Count}) ##");
        person.ToList().ForEach(p => Console.WriteLine(p.Name));
    }
}

internal class PersonManager
{
    private readonly PersonRepository _repository;

    public PersonManager()
    {
        _repository = new PersonRepository();
    }

    public List<Person> GetAllChildren()
    {
        return _repository.Load().Where(p => p.Age < 18).ToList();
    }

    public List<Person> GetAllAdults()
    {
        return _repository.Load().Where(p => p.Age >= 18).ToList();
    }
}

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
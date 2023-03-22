namespace PersonManagerApp.ConsoleClient;

internal class Program
{
    public static void Main(string[] args)
    {
        var person = new Person
        {
            Id = 4711,
            Name = "Hasi",
            Age = 10
        };

        var parser = new PersonParser();
        var repo = new PersonRepository(parser);

        IPersonManager manager = new PersonManager(repo);

        manager.Add(person);

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
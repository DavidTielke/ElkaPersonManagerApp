namespace PersonManagerApp.ConsoleClient;

internal class Program
{
    public static void Main(string[] args)
    {
        var persons = Load();

        var adults = GetAllAdults(persons);
        var children = GetAllChildren(persons);

        PrintPersonList(adults, "Erwachsene");
        PrintPersonList(children, "Kinder");
    }

    private static void PrintPersonList(List<Person> person, string title)
    {
        Console.WriteLine($"## {title} ({person.Count}) ##");
        person.ToList().ForEach(p => Console.WriteLine(p.Name));
    }

    private static List<Person> GetAllChildren(List<Person> persons)
    {
        return persons.Where(p => p.Age < 18).ToList();
    }

    private static List<Person> GetAllAdults(List<Person> persons)
    {
        return persons.Where(p => p.Age >= 18).ToList();
    }

    private static List<Person> Load()
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
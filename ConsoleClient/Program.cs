namespace PersonManagerApp.ConsoleClient;

internal class Program
{
    public static void Main(string[] args)
    {
        var persons = File
            .ReadAllLines("data.csv")
            .Select(l => l.Split(","))
            .Select(p => new Person
            {
                Id = int.Parse(p[0]),
                Name = p[1],
                Age = int.Parse(p[2])
            })
            .ToList();

        var adults = persons.Where(p => p.Age >= 18).ToList();
        var children = persons.Where(p => p.Age < 18).ToList();

        Console.WriteLine($"## Erwachsene ({adults.Count}) ##");
        adults.ToList().ForEach(p => Console.WriteLine(p.Name));

        Console.WriteLine($"## Kinder ({children.Count}) ##");
        children.ToList().ForEach(c => Console.WriteLine(c.Name));
    }
}
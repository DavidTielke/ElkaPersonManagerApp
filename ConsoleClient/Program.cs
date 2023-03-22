using Ninject;

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

        var kernel = new StandardKernel();
        kernel.Bind<IPersonManager>().To<PersonManager>();
        kernel.Bind<IPersonRepository>().To<PersonRepository>();
        kernel.Bind<IPersonParser>().To<PersonParser>();

        var manager = kernel.Get<IPersonManager>();

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
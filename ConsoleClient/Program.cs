using Configuration;
using DavidTielke.PersonManagerApp.CrossCutting.DataModel;
using DavidTielke.PersonManagerApp.Infrastructure.Mappings;
using DavidTielke.PersonManagerApp.Logic.PersonManagement;
using Ninject;

namespace DavidTielke.PersonManagerApp.UI.ConsoleClient;

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

        var kernel = new KernelFactory().Create();

        var config = kernel.Get<IConfigurator>();
        config.Set("AgeThreshold", 10);

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
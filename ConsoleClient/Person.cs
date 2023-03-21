using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace PersonManagerApp.ConsoleClient;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
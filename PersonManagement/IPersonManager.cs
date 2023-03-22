namespace PersonManagerApp.ConsoleClient;

public interface IPersonManager
{
    void Add(Person person);
    List<Person> GetAllChildren();
    List<Person> GetAllAdults();
}
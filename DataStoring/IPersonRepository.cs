namespace PersonManagerApp.ConsoleClient;

public interface IPersonRepository
{
    void Insert(Person person);
    List<Person> Load();
}
namespace PersonManagerApp.ConsoleClient;

public class PersonManager
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
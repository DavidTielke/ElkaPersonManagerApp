namespace PersonManagerApp.ConsoleClient;

public class PersonManager : IPersonManager
{
    private readonly IPersonRepository _repository;

    public PersonManager(IPersonRepository repository)
    {
        _repository = repository;
    }

    public void Add(Person person)
    {
        if (person == null)
        {
            throw new ArgumentNullException(nameof(person));
        }

        var nameIsForbidden = person.Name == "Otto";
        if (nameIsForbidden)
        {
            throw new InvalidOperationException("Cant persons with name otto");
        }

        // logging

        _repository.Insert(person);
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
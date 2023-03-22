using Configuration;
using DavidTielke.PersonManagerApp.CrossCutting.DataModel;
using DavidTielke.PersonManagerApp.Data.DataStoring;

namespace DavidTielke.PersonManagerApp.Logic.PersonManagement;

public interface IAlgo
{
}

public class PersonManager : IPersonManager
{
    private readonly IConfigurator _config;
    private readonly IPersonRepository _repository;
    private readonly int AGE_TRESHOLD;

    public PersonManager(IPersonRepository repository,
        IConfigurator config)
    {
        _repository = repository;
        _config = config;
        AGE_TRESHOLD = _config.Get<int>("AgeThreshold");
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
        return _repository.Load().Where(p => p.Age < AGE_TRESHOLD).ToList();
    }

    public List<Person> GetAllAdults()
    {
        return _repository.Load().Where(p => p.Age >= AGE_TRESHOLD).ToList();
    }
}
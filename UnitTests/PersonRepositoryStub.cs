using DavidTielke.PersonManagerApp.CrossCutting.DataModel;
using DavidTielke.PersonManagerApp.Data.DataStoring;

namespace UnitTests;

public class PersonRepositoryStub : IPersonRepository
{
    public bool InsertWasCalled { get; set; }

    public void Insert(Person person)
    {
        InsertWasCalled = true;
    }

    public List<Person> Load()
    {
        return new List<Person>
        {
            new(1, "Erwachsener1", 18),
            new(2, "Erwachsener2", 19),
            new(3, "Erwachsener2", 17),
            new(4, "Erwachsener2", 0)
        };
    }
}
using DavidTielke.PersonManagerApp.CrossCutting.DataModel;

namespace DavidTielke.PersonManagerApp.Data.DataStoring;

public interface IPersonRepository
{
    void Insert(Person person);
    List<Person> Load();
}
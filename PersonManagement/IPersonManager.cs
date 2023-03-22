using DavidTielke.PersonManagerApp.CrossCutting.DataModel;

namespace DavidTielke.PersonManagerApp.Logic.PersonManagement;

public interface IPersonManager
{
    void Add(Person person);
    List<Person> GetAllChildren();
    List<Person> GetAllAdults();
}
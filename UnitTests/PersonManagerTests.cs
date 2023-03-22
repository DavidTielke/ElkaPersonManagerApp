using DavidTielke.PersonManagerApp.CrossCutting.DataModel;
using DavidTielke.PersonManagerApp.Logic.PersonManagement;

namespace UnitTests;

// MOQ

[TestClass]
public class PersonManagerTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Add_PersonIsNull_ArgumentNullException()
    {
        var repoStub = new PersonRepositoryStub();
        var manager = new PersonManager(repoStub);

        manager.Add(null);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Add_PersonNameOtto_AddIsRejected()
    {
        var repoStub = new PersonRepositoryStub();
        var manager = new PersonManager(repoStub);
        var person = new Person { Name = "Otto" };

        manager.Add(person);
    }

    [TestMethod]
    public void Add_PersonWithValidName_AddIsNotRejected()
    {
        var repoStub = new PersonRepositoryStub();
        var manager = new PersonManager(repoStub);
        var person = new Person { Name = "David" };

        manager.Add(person);

        Assert.IsTrue(repoStub.InsertWasCalled);
    }

    [TestMethod]
    public void Add_PersonAdded_IsInsertedIntoRepo()
    {
        var repoStub = new PersonRepositoryStub();
        var manager = new PersonManager(repoStub);
        var person = new Person { Name = "David" };

        manager.Add(person);

        Assert.IsTrue(repoStub.InsertWasCalled);
    }


    [TestMethod]
    public void GetAllAdults_2AdultsFromRepo_2AdultsReturned()
    {
        var repoStub = new PersonRepositoryStub();
        var manager = new PersonManager(repoStub);
        var expected = 2;

        var actual = manager.GetAllAdults().Count;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetAllAdults_2ChildrenFromRepo_2ChildrensReturned()
    {
        var repoStub = new PersonRepositoryStub();
        var manager = new PersonManager(repoStub);
        var expected = 2;

        var actual = manager.GetAllChildren().Count;

        Assert.AreEqual(expected, actual);
    }
}
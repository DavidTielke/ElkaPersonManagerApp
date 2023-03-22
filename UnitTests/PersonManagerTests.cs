using PersonManagerApp.ConsoleClient;

namespace UnitTests;

// MOQ
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
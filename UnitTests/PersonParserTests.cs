using DavidTielke.PersonManagerApp.Data.DataStoring;

namespace UnitTests;

[TestClass]
public class PersonParserTests
{
    [TestMethod]
    public void Parse_OneValidRecord_OnePersonReturned()
    {
        // Arrange
        var data = new[] { "1,Test,10" };
        var expected = 1;
        var parser = new PersonParser();

        // Act
        var persons = parser.Parse(data);

        // Assert
        Assert.AreEqual(expected, persons.Count);
    }

    [TestMethod]
    public void TestMethod3()
    {
        var data = new[] { "1,Test,10" };
        var parser = new PersonParser();

        var persons = parser.Parse(data);

        Assert.AreEqual(1, persons.Count);
        var person = persons.First();
        Assert.AreEqual(1, person.Id);
        Assert.AreEqual("Test", person.Name);
        Assert.AreEqual(10, person.Age);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Parse_EmptyRecord_FormatException()
    {
        var data = new[] { "" };
        var parser = new PersonParser();

        var persons = parser.Parse(data);
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestMethod2()
    {
        string[] data = null;
        var parser = new PersonParser();

        var persons = parser.Parse(data);
    }
}
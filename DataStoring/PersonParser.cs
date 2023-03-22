using DavidTielke.PersonManagerApp.CrossCutting.DataModel;

namespace DavidTielke.PersonManagerApp.Data.DataStoring;

public interface IPersonParser
{
    List<Person> Parse(string[] lines);
}

public class PersonParser : IPersonParser
{
    public List<Person> Parse(string[] lines)
    {
        if (lines == null)
        {
            throw new ArgumentNullException(nameof(lines));
        }

        for (var i = 0; i < lines.Length; i++)
        {
            var count = lines[i].Split(",").Length;
            if (count != 3)
            {
                throw new FormatException($"Line {i + 1} contains more or less than 3 elements");
            }
        }

        var persons = lines.Select(l => l.Split(","))
            .Select(p => new Person
            {
                Id = int.Parse(p[0]),
                Name = p[1],
                Age = int.Parse(p[2])
            })
            .ToList();
        return persons;
    }
}
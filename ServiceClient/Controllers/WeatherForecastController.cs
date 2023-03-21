using Microsoft.AspNetCore.Mvc;
using PersonManagerApp.ConsoleClient;

namespace ServiceClient.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    [HttpGet]
    [Route("/People/Adults")]
    public IEnumerable<Person> GetAllAdults()
    {
        var manager = new PersonManager();
        return manager.GetAllAdults();
    }


    [HttpGet]
    [Route("/People/Children")]
    public IEnumerable<Person> GetAllChildren()
    {
        var manager = new PersonManager();
        return manager.GetAllChildren();
    }
}
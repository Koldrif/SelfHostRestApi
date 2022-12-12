using ApiWithAsp.DataBase;
using ApiWithAsp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithAsp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    
    

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    // TODO: Add response status 404 if user not found
    [HttpGet]
    public TestItem Get(long? id, string? name)
    {
        if (name is not null)
        {
            return Get(name);
        }
        else if (id is not null)
        {
            return Get((long)id);
        }
        else
        {
            _logger.LogWarning($"id and Name params are empty");
            return null;
        }
    }

    private TestItem Get(long id)
    {
        _logger.LogInformation($"Getting user by id: {id}");
        return UserDb.GetUserById(id);
    }

    private TestItem Get(string Name)
    {
        _logger.LogInformation($"Getting user by username: {Name}");
        return UserDb.GetUserByName(Name);
    }

    [HttpDelete]
    public void Delete(long id)
    {
        _logger.LogInformation(0, $"Removing user with id: {id}");

        UserDb.RemoveUser(id);
        HttpContext.Response.StatusCode = 200;
    }
    
    
    [HttpPost]
    public TestItem Save(TestItem item)
    {        
        // TODO: Get user new id
        _logger.LogInformation( $"Trying to save user {item}");
        var newUser = UserDb.AddUser(item);
        _logger.LogInformation( $"Saved user {newUser}");
        return newUser;
    }
}
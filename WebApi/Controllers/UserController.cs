using Application.LogicInterfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace WebApi.Controllers;

[ApiController] //marks this class as a Web API controller, so that the Web API framework will know about it
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserLogic userLogic;

    public UserController(IUserLogic userLogic) //gets access to application layer
    {
        this.userLogic = userLogic;
    }

    //It should take the relevant data, pass it on to the logic layer, and return the result back to the client.
    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync(UserCreationDto dto)
    {
        try
        {
            User user = await userLogic.CreateAsync(dto);
            return Created($"/users/{user.Id}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}
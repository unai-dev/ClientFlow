using ClientFlow.API.Contracts;
using ClientFlow.Shared.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientFlow.API.Controllers;

[ApiController]
[Route("v1/api/users/")]
[Authorize]
public class UserController: ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> Get() =>
        Ok(await userService.GetUsersAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> Get([FromRoute] int id) =>
        Ok(await userService.GetUserAsync(id));
}

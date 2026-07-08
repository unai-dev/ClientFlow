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
    public async Task<IEnumerable<UserDTO>> Get() =>
        await userService.GetUsersAsync();

    [HttpGet("{id}")]
    public async Task<UserDTO> Get([FromRoute] int id) =>
        await userService.GetUserAsync(id);
}

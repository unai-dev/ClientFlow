using ClientFlow.API.Contracts;
using ClientFlow.Shared.DTOs.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientFlow.API.Controllers;

[ApiController]
[Route("v1/api/clients")]
[Authorize]
public class ClientController : ControllerBase
{
    private readonly IClientService clientService;

    public ClientController(IClientService clientService)
    {
        this.clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDTO>>> Get() =>
        Ok(await clientService.GetClientsAsync());

    [HttpGet("{id:int}", Name = "GetClient")]
    public async Task<ActionResult<ClientDTO>> Get([FromRoute] int id) =>
        Ok(await clientService.GetClientAsync(id));

    [HttpPost]
    public async Task<ActionResult<ClientDTO>> Post([FromBody] CreateClientDTO createClientDTO)
    {
        var result = await clientService.CreateClientAsync(createClientDTO);

        return result is not null ? CreatedAtRoute("GetClient", new { id = result.Id }, result) : BadRequest();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await clientService.DeleteClientAsync(id);

        return result ? NoContent() : NotFound();
    }

}

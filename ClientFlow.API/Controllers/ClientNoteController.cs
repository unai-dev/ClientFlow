using ClientFlow.API.Interfaces;
using ClientFlow.Shared.DTOs.ClientNote;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientFlow.API.Controllers
{
    [ApiController]
    [Route("v1/api/notes/")]
    [Authorize]
    public class ClientNoteController : ControllerBase
    {
        private readonly IClientNoteService clientNoteService;

        public ClientNoteController(IClientNoteService clientNoteService)
        {
            this.clientNoteService = clientNoteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientNoteDTO>>> Get([FromRoute] int clientId)
        {
            var result = await clientNoteService.GetClientNotesAsync(clientId);

            return result is not null ? Ok(result) : NotFound("Client not found");
        }

        [HttpPost("{clientId}")]
        public async Task<ActionResult<ClientNoteDTO>> Post([FromBody] CreateClientNoteDTO createClientNoteDTO, [FromRoute] int clientId)
        {
            var result = await clientNoteService.CreateClientNoteAsync(clientId, createClientNoteDTO);

            return result is not null ? Ok(result) : BadRequest();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delte([FromRoute] Guid id)
        {
            var result = await clientNoteService.DeleteClientNoteAsync(id);

            return result ? NoContent() : NotFound();
        }

    }
}

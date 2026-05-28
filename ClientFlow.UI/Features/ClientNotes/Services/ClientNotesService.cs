using ClientFlow.Shared.DTOs.ClientNote;
using ClientFlow.UI.Features.ClientNotes.Interfaces;
using System.Net.Http.Json;

namespace ClientFlow.UI.Features.ClientNotes.Services
{
    public class ClientNotesService : IClientNotesService
    {
        private readonly HttpClient httpClient;

        public ClientNotesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<ClientNoteDTO?>> GetClientNotesAsync(int clientId)
        {
            return await httpClient.GetFromJsonAsync<List<ClientNoteDTO?>>($"clients/{clientId}/notes");
        }

        public async Task<ClientNoteDTO?> CreateClientNoteAsync(int clientId, CreateClientNoteDTO noteDTO)
        {
            var response = await httpClient.PostAsJsonAsync($"clients/{clientId}/notes", noteDTO);
            return await response.Content.ReadFromJsonAsync<ClientNoteDTO>();
        }


        public async Task<bool?> DeleteClientNoteAsync(int clientId, int id)
        {
            var response = await httpClient.DeleteAsync($"clients/{clientId}/notes/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

using AutoMapper;
using ClientFlow.API.Entities;
using ClientFlow.Shared.DTOs.ClientNote;

namespace ClientFlow.API.Utils.AutoMapperProfiles
{
    public class ClientNoteProfile : Profile
    {
        public ClientNoteProfile()
        {
            CreateMap<ClientNote, ClientNoteDTO>();
            CreateMap<CreateClientNoteDTO, ClientNote>();
        }
    }
}

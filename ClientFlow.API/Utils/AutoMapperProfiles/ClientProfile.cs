using AutoMapper;
using ClientFlow.API.Entities;
using ClientFlow.Shared.DTOs.Client;

namespace ClientFlow.API.Utils.AutoMapperProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<CreateClientDTO, Client>();
        }
    }
}

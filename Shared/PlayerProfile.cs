using AutoMapper;
using Casino.Core.Models;
using Shared.DTOs;

namespace Shared
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerDto,Player>().ReverseMap();
        }

    }
}

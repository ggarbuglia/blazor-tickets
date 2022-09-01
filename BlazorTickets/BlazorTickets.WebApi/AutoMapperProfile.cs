using AutoMapper;
using BlazorTickets.DataObjects;
using BlazorTickets.Entities;

namespace BlazorTickets.WebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SystemGroup, SystemGroupDto>().ReverseMap();
            CreateMap<SystemUser, SystemUserDto>().ReverseMap();
            CreateMap<TicketType, TicketTypeDto>().ReverseMap();
            CreateMap<TicketStatus, TicketStatusDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using RentAnUmpireWebApi.Dtos;
using RentAnUmpireWebApi.Entities;


namespace RentAnUmpireWebApi.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
using AutoMapper;
using RandRestaurantSelector.DataTransferObjects;
using RandRestaurantSelector.Models;

namespace RandRestaurantSelector.Managers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}

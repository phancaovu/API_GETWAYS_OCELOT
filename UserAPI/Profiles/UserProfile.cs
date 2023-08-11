using AutoMapper;
using UserAPI.DTO;
using UserAPI.Models;

namespace UserAPI.Profiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
        }
        // map object 
        /*public class MappingProfile : Profile
            {
                public MappingProfile()
                {
                    //Source -> Destination
                    CreateMap<User, UserReadDto>()
                        .ForMember(
                            dest => dest.FullName,
                            opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                        .ForMember(
                            dest => dest.Age,
                            opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge())
                            );

                    CreateMap<UserCreateDto, User>();
                }
            }*/
    }
}

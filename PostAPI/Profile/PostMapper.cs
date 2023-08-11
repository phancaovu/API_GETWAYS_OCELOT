
using AutoMapper;
using PostAPI.DTO;
using PostAPI.Models;

namespace PostAPI.Profile
{
    public class PostMapper : AutoMapper.Profile
    {
        public PostMapper()
        {
            CreateMap<PostModels, PostDTO>();
        }
    }
}

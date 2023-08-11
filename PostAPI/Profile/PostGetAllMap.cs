using AutoMapper;
using PostAPI.DTO;
using PostAPI.Models;

namespace PostAPI.Profile
{
    public class PostGetAllMap : AutoMapper.Profile
    {
        public PostGetAllMap() {
            CreateMap<PostModels, PostGetAllDTO>();
        }
    }
}

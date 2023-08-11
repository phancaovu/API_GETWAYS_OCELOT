using PostAPI.DTO;
using PostAPI.Models;

namespace PostAPI.Repository
{
    public interface IPostRepository
    {
        public Task<List<PostGetAllDTO>> GetAllPostAsync();
        public Task<PostDTO> GetPostAsync(int PostID);

        public Task<int> AddPostAsync(PostAPI.Models.PostModels Post);
        public Task UpdatePostAsync(int PostID, PostModels Postmodel);
        public Task DeletePostAsync(int PostID);
        Task GetPostAsync(object PostID);
    }
}

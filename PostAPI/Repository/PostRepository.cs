using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostAPI.Data;
using PostAPI.DTO;
using PostAPI.Models;

namespace PostAPI.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly PostStoreContext _context;
        private readonly IMapper _mapper;
        public PostRepository(PostStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddPostAsync(PostModels Post)
        {
            var newPost = _mapper.Map<PostModels>(Post);
            _context.PostModelss!.Add(newPost);
            await _context.SaveChangesAsync();
            return newPost.PostID;
        }

        public async Task DeletePostAsync(int PostID)
        {
            var deletePost = _context.PostModelss!.SingleOrDefault(b => b.PostID == PostID);
            if (deletePost != null)
            {
                _context.PostModelss!.Remove(deletePost);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PostGetAllDTO>> GetAllPostAsync()
        {
            var Posts = await _context.PostModelss!.ToListAsync();
            return _mapper.Map<List<PostGetAllDTO>>(Posts);
        }

        public async Task<PostDTO> GetPostAsync(int PostID)
        {
            var Post = await _context.PostModelss!.FindAsync(PostID);
            return _mapper.Map<PostDTO>(Post);
        }

        public Task GetPostAsync(object PostID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePostAsync(int PostID, PostModels Postmodel)
        {
            if (PostID == Postmodel.PostID)
            {
                var updatePost = _mapper.Map<PostModels>(Postmodel);
                _context.PostModelss!.Update(updatePost);
                await _context.SaveChangesAsync();
            }
        }
    }
}

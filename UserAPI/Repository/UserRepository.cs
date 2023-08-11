using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.DTO;
using UserAPI.Models;
using UserAPI.Repository;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserStoreContext _context;
        private readonly IMapper _mapper;
        public UserRepository(UserStoreContext userStoreContext, IMapper mapper)
        {
            _context = userStoreContext;
            _mapper = mapper;
        }

        public async Task<int> AddUserAsync(User user)
        {
            var newUser = _mapper.Map<User>(user);
            _context.Users!.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser.UserID;
        }

        public async Task DeleteUserAsync(int UserID)
        {
            var deleteBook = _context.Users!.SingleOrDefault(b => b.UserID == UserID);
            if (deleteBook != null)
            {
                _context.Users!.Remove(deleteBook);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UserDTO>> GetAllUserAsync()
        {
            var Users = await _context.Users!.ToListAsync();
            return _mapper.Map<List<UserDTO>>(Users);
        }

        public async Task<UserDTO> GetUserAsync(int UserID)
        {
            var user = await _context.Users!.FindAsync(UserID);
            return _mapper.Map<UserDTO>(user);
        }

        public Task GetUserAsync(object userID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(int UserID, User usermodel)
        {
            if (UserID == usermodel.UserID)
            {
                var updateBook = _mapper.Map<User>(usermodel);
                _context.Users!.Update(updateBook);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using UserAPI.Models;
using UserAPI.DTO;

namespace UserAPI.Repository
{
    public interface IUserRepository
    {
        public Task<List<UserDTO>> GetAllUserAsync();
        public Task<UserDTO> GetUserAsync(int UserID);

        public Task<int> AddUserAsync(UserAPI.Models.User user);
        public Task UpdateUserAsync(int UserID, User usermodel);
        public Task DeleteUserAsync(int UserID);
        Task GetUserAsync(object userID);
    }
}

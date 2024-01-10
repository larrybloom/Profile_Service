using ProfileService.Data.DTOs;
using ProfileService.Entities;

namespace ProfileService.Services.Interface
{
    public interface IAppUserService
    {
        Task AddUserAsync(userDTO user);
        Task<AppUser?> GetUserByIdAsync(string id);
        Task UpdateUserAsync(AppUser user);
        Task DeleteUserAsync(string id);
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
    }
}

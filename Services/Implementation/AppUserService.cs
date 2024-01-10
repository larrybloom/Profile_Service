using AutoMapper;
using ProfileService.Data.DTOs;
using ProfileService.Data.Repository.Interface;
using ProfileService.Entities;
using ProfileService.Services.Interface;

namespace ProfileService.Services.Implementation
{
    public class AppUserService : IAppUserService
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public AppUserService(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddUserAsync(userDTO user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            AppUser appUser = _mapper.Map<AppUser>(user);

            await _repository.AddAsync(appUser);
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user != null)
            {
                await _repository.DeleteAsync(user);
            }
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            try
            {
                var users = await _repository.GetAllAsync2();
                return users;
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error retrieving all users: {ex.Message}");
                throw; // Rethrow the exception to propagate it up the stack
            }
        }

        public async Task<AppUser?> GetUserByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);

        }

        public async Task UpdateUserAsync(AppUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _repository.UpdateAsync(user);
        }
    }
}

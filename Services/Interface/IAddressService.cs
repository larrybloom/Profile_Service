using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProfileService.Data.DTOs;

namespace ProfileService.Services.Interface
{
    public interface IAddressService
    {
        Task<IEnumerable<addressDTO>> GetAllAddressesAsync();
        Task<addressDTO?> GetAddressByIdAsync(Guid id);
        Task AddAddressAsync(addressDTO address);
        Task UpdateAddressAsync(Guid id, addressDTO address);
        Task DeleteAddressAsync(Guid id);
    }
}

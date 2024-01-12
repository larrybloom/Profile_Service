using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProfileService.Data.DTOs;
using ProfileService.Data.Repository.Interface;
using ProfileService.Entities;
using ProfileService.Services.Interface;

namespace ProfileService.Services.Implementation
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IRepository<Address> addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<addressDTO>> GetAllAddressesAsync()
        {
            var addresses = await _addressRepository.GetAllAsync2();
            return _mapper.Map<IEnumerable<addressDTO>>(addresses);
        }

        public async Task<addressDTO?> GetAddressByIdAsync(Guid id)
        {
            var address = await _addressRepository.GetByIdAsync(id.ToString());
            return _mapper.Map<addressDTO>(address);
        }

        public async Task AddAddressAsync(addressDTO address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            var addressEntity = _mapper.Map<Address>(address);
            await _addressRepository.AddAsync(addressEntity);
        }

        public async Task UpdateAddressAsync(Guid id, addressDTO address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            var existingAddress = await _addressRepository.GetByIdAsync(id.ToString());

            if (existingAddress == null)
                throw new KeyNotFoundException($"Address with Id {id} not found.");

            _mapper.Map(address, existingAddress);
            await _addressRepository.UpdateAsync(existingAddress);
        }

        public async Task DeleteAddressAsync(Guid id)
        {
            var address = await _addressRepository.GetByIdAsync(id.ToString());

            if (address != null)
            {
                await _addressRepository.DeleteAsync(address);
            }
        }
    }
}

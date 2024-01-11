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
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository<Organization> _organizationRepository;
        private readonly IMapper _mapper;

        public OrganizationService(IRepository<Organization> organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<organizationDTO>> GetAllOrganizationsAsync()
        {
            var organizations = await _organizationRepository.GetAllAsync2();
            return _mapper.Map<IEnumerable<organizationDTO>>(organizations);
        }

        public async Task<organizationDTO?> GetOrganizationByIdAsync(Guid id)
        {
            var organization = await _organizationRepository.GetByIdAsync(id.ToString());
            return _mapper.Map<organizationDTO>(organization);
        }

        public async Task AddOrganizationAsync(organizationDTO organization)
        {
            if (organization == null)
                throw new ArgumentNullException(nameof(organization));

            var organizationEntity = _mapper.Map<Organization>(organization);
            await _organizationRepository.AddAsync(organizationEntity);
        }

        public async Task UpdateOrganizationAsync(Guid id, organizationDTO organization)
        {
            if (organization == null)
                throw new ArgumentNullException(nameof(organization));

            var existingOrganization = await _organizationRepository.GetByIdAsync(id.ToString());

            if (existingOrganization == null)
                throw new KeyNotFoundException($"Organization with Id {id} not found.");

            _mapper.Map(organization, existingOrganization);
            await _organizationRepository.UpdateAsync(existingOrganization);
        }

        public async Task DeleteOrganizationAsync(Guid id)
        {
            var organization = await _organizationRepository.GetByIdAsync(id.ToString());

            if (organization != null)
            {
                await _organizationRepository.DeleteAsync(organization);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileService.Data.DTOs;

namespace ProfileService.Services.Interface
{
    public interface IOrganizationService
    {
        Task<IEnumerable<organizationDTO>> GetAllOrganizationsAsync();
        Task<organizationDTO?> GetOrganizationByIdAsync(Guid id);
        Task AddOrganizationAsync(organizationDTO organization);
        Task UpdateOrganizationAsync(Guid id, organizationDTO organization);
        Task DeleteOrganizationAsync(Guid id);
    }
}

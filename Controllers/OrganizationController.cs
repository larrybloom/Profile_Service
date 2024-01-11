using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Data.DTOs;
using ProfileService.Services.Interface;

namespace ProfileService.Controllers
{
    [ApiController]
    [Route("api/organizations")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrganizations()
        {
            try
            {
                var organizations = await _organizationService.GetAllOrganizationsAsync();
                return Ok(organizations);
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error getting organizations: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizationById(Guid id)
        {
            try
            {
                var organization = await _organizationService.GetOrganizationByIdAsync(id);
                if (organization == null)
                    return NotFound($"Organization with Id {id} not found");

                return Ok(organization);
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error getting organization by Id: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrganization([FromBody] organizationDTO organization)
        {
            try
            {
                await _organizationService.AddOrganizationAsync(organization);
                return CreatedAtAction(nameof(GetOrganizationById), new { id = organization.Code }, organization);
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error adding organization: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganization(Guid id, [FromBody] organizationDTO organization)
        {
            try
            {
                await _organizationService.UpdateOrganizationAsync(id, organization);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Organization with Id {id} not found");
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error updating organization: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(Guid id)
        {
            try
            {
                await _organizationService.DeleteOrganizationAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error deleting organization: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

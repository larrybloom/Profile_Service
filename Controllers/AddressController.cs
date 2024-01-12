using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Data.DTOs;
using ProfileService.Services.Interface;

namespace ProfileService.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            try
            {
                var addresses = await _addressService.GetAllAddressesAsync();
                return Ok(addresses);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting addresses: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(Guid id)
        {
            try
            {
                var address = await _addressService.GetAddressByIdAsync(id);
                if (address == null)
                    return NotFound($"Address with Id {id} not found");

                return Ok(address);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting address by Id: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress([FromBody] addressDTO address)
        {
            try
            {
                await _addressService.AddAddressAsync(address);
                return CreatedAtAction(nameof(GetAddressById), new { id = address.Name }, address);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding address: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(Guid id, [FromBody] addressDTO address)
        {
            try
            {
                await _addressService.UpdateAddressAsync(id, address);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Address with Id {id} not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating address: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            try
            {
                await _addressService.DeleteAddressAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting address: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

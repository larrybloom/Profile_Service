using System.ComponentModel.DataAnnotations;

namespace ProfileService.Data.DTOs
{
    public class userDTO
    {
        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public string CountryCode { get; set; }

        public string Email { get; set; }


    }
}

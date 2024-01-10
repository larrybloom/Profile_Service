using Microsoft.AspNetCore.Identity;
using ProfileService.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileService.Entities
{
    public class AppUser : IdentityUser
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? Login { get; set; }
        public string? CountryCode { get; set; }
        public string? DateOfBirth { get; set; }
        public DateTime lastSeen { get; set; } = DateTime.Now;
        public DateTime firstSeen { get; set; } = DateTime.Now;
        public string? Language { get; set; }
        public string? imageUrl { get; set; }
        public bool Activation { get; set; } = false;
        public ProfileStatus Status { get; set; }
        public profileType profileType { get; set; }

        public Guid AddressId { get; set; }
        public Address? Address { get; set; }

        public HashSet<Organization>? Organization { get; set; } = new HashSet<Organization>();

        public Guid RolesId { get; set; }
        public Roles? Roles { get; set; }

        public Guid RevokeTokenId { get; set; }
        public RevokeToken? RevokeToken { get; set; }

        public Guid RefreshTokenId { get; set; }
        public RefreshToken? RefreshToken { get; set; }

    }
}

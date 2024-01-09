using ProfileService.Entities.Enum;

namespace ProfileService.Entities
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public string LogoUrl { get; set; }
        public OrganizationType OrganizationType { get; set; }
        public string Language { get; set; }
        public bool Active { get; set; }
       
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public Guid OrganizationRolesId { get; set; }
        public OrganizationRoles OrganizationRoles { get; set; }
    }
}

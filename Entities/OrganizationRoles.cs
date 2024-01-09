using ProfileService.Entities.Enum;

namespace ProfileService.Entities
{
    public class OrganizationRoles
    {
        public Guid Id { get; set; }
        public Guid RolesId { get; set; }
        public Roles Roles { get; set; }

        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}

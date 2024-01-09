using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileService.Entities
{
    public class Roles
    {
        [Key]
       public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool DefaultRoles { get; set; }
        public bool UserDefinedRoles { get; set; }
        public Privileges Privileges { get; set; }
         
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public Guid OrganizationRolesId { get; set; }
        public OrganizationRoles OrganizationRoles{ get; set; }
    }
}

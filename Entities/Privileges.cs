using System.ComponentModel.DataAnnotations;

namespace ProfileService.Entities
{
    public class Privileges
    {
        [Key]
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid RolesId { get; set; }
        public Roles Roles { get; set; }
    }
}

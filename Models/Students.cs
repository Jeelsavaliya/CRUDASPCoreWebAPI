using System.ComponentModel.DataAnnotations;

namespace CRUDASPCoreWebAPI.Models
{
    public class Students
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Standard { get; set; }
        [Required]
        public string School { get; set; }
        [Required]
        public int Age { get; set; }

    }
}

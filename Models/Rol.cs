using System.ComponentModel.DataAnnotations;

namespace INV_APPLICATION.Models
{
    public class Rol
    {
        [Key]
       public int Id { get; set; }

        [Required]
        public string RolName { get; set; }    
    }
}

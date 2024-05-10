using System.ComponentModel.DataAnnotations;

namespace INV_APPLICATION.Models
{
    public class Zone
    {
        [Key]
        public string Code { get; set; }
        [Required]
        [Display(Name ="Zona")]
        public  string Province { get; set; }
    }
}

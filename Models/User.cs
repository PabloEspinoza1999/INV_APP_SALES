using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INV_APPLICATION.Models
{
    public class User : Control
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Se requiere el nombre de usuario")]
        [MaxLength(100)]
        [Display(Name ="Usuario")]
        public string UserName { get; set; }


        [Required(ErrorMessage ="Requiere la contraeña")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [MaxLength(10,ErrorMessage ="La contraseña debe de contener menos de 10 digitos")]
        public string Password { get; set; }


        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required(ErrorMessage = "El rol es requerido")]
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }    
     

    }
}

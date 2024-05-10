using System;
using System.ComponentModel.DataAnnotations;

namespace INV_APPLICATION.Models
{
    public class Customer : Control
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre completo es requerido.")]
        [StringLength(255, ErrorMessage = "El nombre completo no puede exceder los {1} caracteres.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "La descripción es requerida.")]
        [StringLength(250, ErrorMessage = "La descripción no puede exceder los {1} caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El número de celular es requerido.")]
        [Phone(ErrorMessage = "Por favor ingrese un número de celular válido.")]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "Por favor ingrese un correo electrónico válido.")]
        public string Email { get; set; }

        [Display(Name = "NIF")]
        public string? NIF { get; set; }


        [Display(Name = "Fecha de Creación")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string ZoneCode { get; set; }
        public virtual Zone Zone { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INV_APPLICATION.Models
{
    public class Product : Control
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Codigo")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [Display(Name = "Producto")]
        [MaxLength(100, ErrorMessage = "El nombre del producto no puede exceder los 100 caracteres.")]
        public string ProductName { get; set; }


        public string ImgUrl { get; set; }


        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [Display(Name = "Descripción")]
        [MaxLength(200, ErrorMessage = "La descripción no puede exceder los 200 caracteres.")]
        public string Description { get; set; }
        [Display(Name = "Stock")]
        public int Stock { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace INV_APPLICATION.Models
{
    public class Control
    {
        [Display(Name = "Fecha de Creación")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

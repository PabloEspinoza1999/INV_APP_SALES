using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INV_APPLICATION.Models
{
    public class Sale : Control
    {
        [Key]
        public int Id { get; set; }

        public int IdCustomer { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        // Detalles de la venta
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Subtotal { get; set; }

        // Claves foráneas
        [ForeignKey("IdCustomer")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}

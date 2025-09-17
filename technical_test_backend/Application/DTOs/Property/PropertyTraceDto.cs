using System.ComponentModel.DataAnnotations;

namespace technical_test.Application.DTOs.Property
{
    public class PropertyTraceDto
    {
        [Required(ErrorMessage = "La fecha de venta es requerida")]
        public DateOnly DateSale { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El valor es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El valor debe ser mayor que 0")]
        public double Value { get; set; }

        [Required(ErrorMessage = "El impuesto es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El impuesto debe ser mayor o igual que 0")]
        public double Tax { get; set; }
    }
}
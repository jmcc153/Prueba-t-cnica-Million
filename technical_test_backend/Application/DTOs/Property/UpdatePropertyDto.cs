using System.ComponentModel.DataAnnotations;

namespace technical_test.Application.DTOs.Property
{
    public class UpdatePropertyDto
    {
        [Required(ErrorMessage = "El ID es requerido")]
        public string Id { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La direcci�n es requerida")]
        [StringLength(200, ErrorMessage = "La direcci�n no puede exceder 200 caracteres")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        public double Price { get; set; }

        [Required(ErrorMessage = "El c�digo interno es requerido")]
        [StringLength(50, ErrorMessage = "El c�digo interno no puede exceder 50 caracteres")]
        public string CodeInternal { get; set; } = string.Empty;

        [Required(ErrorMessage = "El a�o es requerido")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "El a�o debe tener 4 d�gitos")]
        public string Year { get; set; } = string.Empty;

        [Required(ErrorMessage = "El ID del propietario es requerido")]
        public string OwnerId { get; set; } = string.Empty;

        public List<PropertyTraceDto>? Traces { get; set; }
        public List<PropertyImageDto>? Images { get; set; }
    }
}
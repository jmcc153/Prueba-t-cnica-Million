using System.ComponentModel.DataAnnotations;

namespace technical_test.Application.DTOs.Owner
{
    public class UpdateOwnerDto
    {

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La direcci�n es requerida")]
        [StringLength(200, ErrorMessage = "La direcci�n no puede exceder 200 caracteres")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateOnly BirthDate { get; set; }

        [Url(ErrorMessage = "La URL de la foto debe ser v�lida")]
        public IFormFile? Photo { get; set; }
    }
}
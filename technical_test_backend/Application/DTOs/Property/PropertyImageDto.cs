using System.ComponentModel.DataAnnotations;

namespace technical_test.Application.DTOs.Property
{
    public class PropertyImageDto
    {
        [Required(ErrorMessage = "La URL del archivo es requerida")]
        [Url(ErrorMessage = "La URL debe ser válida")]
        public string FileUrl { get; set; } = string.Empty;

        public bool Enabled { get; set; } = true;
    }
}
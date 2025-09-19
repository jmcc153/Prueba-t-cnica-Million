using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace technical_test.Application.DTOs.Property
{
    // DTO para recibir imágenes (crear/actualizar)
    public class PropertyImageInputDto
    {
        [Required(ErrorMessage = "La imagen es requerida")]
        public IFormFile FileUrl { get; set; }
        public bool Enabled { get; set; } = true;
    }

    // DTO para devolver imágenes (consultas)
    public class PropertyImageDto
    {
        [JsonIgnore]
        public byte[] FileData { get; set; }
        
        public bool Enabled { get; set; } = true;
        
        [JsonPropertyName("fileUrl")]
        public string FileUrl => FileData != null ? Convert.ToBase64String(FileData) : null;
        
        [JsonPropertyName("src")]
        public string Src => FileData != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(FileData)}" : null;
    }
}
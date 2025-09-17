namespace technical_test.Application.DTOs.Property
{
    public class PropertyResponseDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public List<PropertyTraceDto>? Traces { get; set; }
        public List<PropertyImageDto>? Images { get; set; }
    }
}
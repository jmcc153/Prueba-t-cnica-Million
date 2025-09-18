using technical_test.Application.DTOs.Owner;
using technical_test.Core.Entities;

namespace technical_test.Application.DTOs.Property
{
    public class PropertyOwnerResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }

        public string CodeInternal { get; set; }
        public string Year { get; set; }
        public string OwnerId { get; set; }
        public OwnerDto OwnerInfo { get; set; }
        public List<PropertyTrace>? Traces { get; set; }
        public List<PropertyImage>? Images { get; set; }
    }
}

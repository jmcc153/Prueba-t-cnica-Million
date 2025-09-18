namespace technical_test.Application.DTOs.Owner
{
    public class OwnerDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public byte[] Photo { get; set; }
    }
}

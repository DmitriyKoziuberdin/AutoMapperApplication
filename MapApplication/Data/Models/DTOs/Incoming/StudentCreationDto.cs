namespace MapApplication.Data.Models.DTOs.Incoming
{
    public class StudentCreationDto
    {
        public Guid Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public int StudentNumber { get; set; }
    }
}

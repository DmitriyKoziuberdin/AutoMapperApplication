using Microsoft.AspNetCore.Mvc;

namespace MapApplication.Data.Models
{
    public class Students
    {
        public Guid Id { get; set; }
        public string FrstName { get; set; } = string.Empty;
        public string LastName { get; set;} = string.Empty;
        public int StudentNumber { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}

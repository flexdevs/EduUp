using System.ComponentModel.DataAnnotations;

namespace EduUp.Service.Dtos.Verify
{
    public class EmailMessageDto
    {
        [Required]
        public string To { get; set; } = string.Empty;
        [Required]
        public int Body { get; set; }
        [Required]
        public string Subject { get; set; } = string.Empty;
    }
}

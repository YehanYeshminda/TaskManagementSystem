using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class TaskUpdateDto
    {
        [Required]
        public int? Qty { get; set; }
        [Required]
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
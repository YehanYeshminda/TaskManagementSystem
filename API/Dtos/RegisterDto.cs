using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }        
    }
}
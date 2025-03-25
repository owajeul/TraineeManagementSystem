using System.ComponentModel.DataAnnotations;

namespace TraineeManagementSystem.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string University { get; set; } = string.Empty;

        [Required]
        public string Technology { get; set; } = string.Empty ;

        [Required, Phone]
        public string Phone { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

    }

}

using System.ComponentModel.DataAnnotations;

namespace MyAPI.src.Model.Entities.User
{
    public class UserInputModel
    {

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The first name must have between 3 and 100 characteres.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The last name must have between 3 and 100 characteres.")]
        public string LastName { get; set; }

        [Required]
        [Range(12, 99, ErrorMessage = "The age must be between 12 and 99.")]
        public int Age { get; set; }

        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Username must have at least 3 characteres.")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Password must have at least 5 characteres.")]
        public string Password { get; set; }

    }
}

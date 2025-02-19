namespace EduManage.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters.")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        [MinLength(3, ErrorMessage = "Last name must be at least 3 characters.")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(20, 35, ErrorMessage = "Age must be between 20 and 35.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
       
        [Remote("CheckEmailExistance", "Student", AdditionalFields = "Fname,Id", ErrorMessage = "Email already exists.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
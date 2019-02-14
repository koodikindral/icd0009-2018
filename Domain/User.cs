using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User: BaseEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Username { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string LastName { get; set; }

       
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        
        public string FirstLastName => FirstName + " " + LastName;
    }
}
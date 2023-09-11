using AlkemyUmsa.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyUmsa.Entities
{

    public class User
    {
        public User(RegisterDto dto)
        {
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Email = dto.Email;
            Password = dto.Password;
        }

        public User(RegisterDto dto, int id)
        {
            Id = id;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Email = dto.Email;
            Password = dto.Password;
        }

        public User()
        {
            
        }

        [Key]
        [Column("user_id")]
        public int Id { get; set; }

        [Required]
        [Column("user_firstName", TypeName = "VARCHAR(100)")]
        public string FirstName { get; set; }

        [Required]
        [Column("user_lastName", TypeName = "VARCHAR(100)")]
        public string LastName { get; set; }    
        
        [Required]
        [Column("user_email", TypeName = "VARCHAR(100)")]
        public string Email { get; set; } 
        
        [Required]
        [Column("user_password", TypeName = "VARCHAR(50)")]
        public string Password { get; set; }

    }
}

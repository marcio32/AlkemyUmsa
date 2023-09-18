using AlkemyUmsa.DTOs;
using AlkemyUmsa.Helper;
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
            RoleId = 2;
            Password = PasswordEncryptHelper.EncryptPassword(dto.Password, dto.Email);
        }

        public User(RegisterDto dto, int id)
        {
            Id = id;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Email = dto.Email;
            RoleId = dto.RoleId;
            Password = PasswordEncryptHelper.EncryptPassword(dto.Password, dto.Email);
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
        [Column("user_password", TypeName = "VARCHAR(250)")]
        public string Password { get; set; }

        [Required]
        [Column("role_id")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

    }
}

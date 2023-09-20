using AlkemyUmsa.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyUmsa.Entities
{
    public class Account
    {
        [Column("account_id")]
        public int Id { get; set; }
        [Required]
        [Column("account_creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Required]
        [Column("account_money", TypeName = "decimal(18,2)")]
        public decimal Money { get; set; } = 1;
        [Required]
        [Column("account_isBlocked")]
        public bool IsBlocked { get; set; } = false;
        
        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        public User? User { get; set; }


        public Account()
        {
                
        }

        public Account(AccountDto dto)
        {
            Id = dto.Id;
            Money = dto.Money;
            IsBlocked = dto.IsBlocked;
        }
    }
}

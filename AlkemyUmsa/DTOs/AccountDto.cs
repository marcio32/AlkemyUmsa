namespace AlkemyUmsa.DTOs
{
    public class AccountDto
    {
        public int Id { get; set; }
        public decimal Money { get; set; }
        public bool IsBlocked { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

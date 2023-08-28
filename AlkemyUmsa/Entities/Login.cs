namespace AlkemyUmsa.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Active { get; set; }
    }
}
    
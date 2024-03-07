namespace AppCasasAPI.Model
{
    public class PedidoVisitaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int FkImovelId { get; set; }
    }
}
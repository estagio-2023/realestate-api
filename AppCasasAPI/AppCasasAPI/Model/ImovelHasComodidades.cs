namespace AppCasasAPI.Models
{
    public class ImovelHasComodidades
    {
        public int Fk_comodidades_id { get; set; }
        public int FkImovelId { get; set; }
        public int FkComodidadesId { get; set; }
    }
}
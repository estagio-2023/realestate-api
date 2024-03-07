namespace AppCasasAPI.Models
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Morada { get; set; }
        public string CPostal { get; set; }
        public string Descricao { get; set; }
        public DateTime AnoConstrucao { get; set; }
        public float preco { get; set; }     
        public int MetrosQuadrados { get; set; }
        public string ClasseEnergetica { get; set; }
        public int FkClienteId { get; set; }
        public int FkVendedorId { get; set; }
        public int FkTipoImovelId { get; set; }
        public int FkCidadesId { get; set; }
        public int FkTipologiaId { get; set; }
    }
}
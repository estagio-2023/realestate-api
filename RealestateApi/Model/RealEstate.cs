namespace RealEstateApi.Model
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public DateTime Build_Date { get; set; }
        public float Price { get; set; }     
        public int SquareMeter { get; set; }
        public string EnergyClass { get; set; }
        public int FkClientId { get; set; }
        public int FkAgentId { get; set; }
        public int FkRealEstateId { get; set; }
        public int FkCityId { get; set; }
        public int FkTypologyId { get; set; }
    }
}
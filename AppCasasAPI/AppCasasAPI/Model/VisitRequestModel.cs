namespace AppCasasAPI.Model
{
    public class VisitRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int FkRealEstateId { get; set; }
    }
}
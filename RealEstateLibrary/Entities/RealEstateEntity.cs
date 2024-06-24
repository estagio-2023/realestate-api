using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Entities
{
    public class RealEstateEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int BuildDate { get; set; }
        public decimal Price { get; set; }
        public int SquareMeter { get; set; }
        public string EnergyClass { get; set; } = null!;
        public int CustomerId { get; set; }
        public int RealEstateTypeId { get; set; }
        public int CityId { get; set; }
        public int TypologyId { get; set; }
        public CustomerEntity Customer { get; set; }
        public RealEstateTypeEntity RealEstateType { get; set; }
        public CityEntity City { get; set; }
        public TypologyEntity Typology { get; set; }
        public List <VisitRequestEntity> VisitRequests { get; set; }
        public List <RealEstateHasAmenityEntity> RealEstateHasAmenities { get; set; }
    }
}

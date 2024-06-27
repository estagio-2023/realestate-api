using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Entities
{
    public class CityEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public List<RealEstateEntity> RealEstates { get; set;}
    }
}

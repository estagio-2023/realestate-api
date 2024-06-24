using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary.Entities
{
    public class VisitRequestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool Confirmed { get; set; }
        public int RealEstateId { get; set; }
        public int AgentId { get; set; }
        public AgentEntity Agent { get; set; }
        public RealEstateEntity RealEstates { get;}
    }
}

﻿namespace RealEstateLibraryEF.Entity
{
    public class VisitRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateOnly Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool Confirmed { get; set; }
        public int AgentId { get; set; }
        public int RealEstateId { get; set; }
        public Agent Agent { get; set; } = null!;
        public RealEstate RealEstate { get; set; } = null!;
    }
}
using System;
using System.Collections.Generic;
using GreenHouse.Core.Enums;
using GreenHouse.Core.Tools;

namespace GreenHouse.Core.Models
{
    public class Report : IIdentifier
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }

        public DateTime ReportedAt { get; set; }
        
        public DateTime FinishedAt { get; set; }
        
        public bool IsScheduled { get; set; }
        
        public string Description { get; set; }

        public ForestState State { get; set; }
        
        public Account Account { get; set; }
        
        public List<Contributor> Contributors { get; set; }
        
        public Schedule Schedule { get; set; }
    }
}
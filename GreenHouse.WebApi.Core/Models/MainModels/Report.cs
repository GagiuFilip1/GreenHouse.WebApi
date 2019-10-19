using System;
using System.Collections.Generic;
using GreenHouse.Core.Models.Enums;
using GreenHouse.Core.Models.Tools;

namespace GreenHouse.Core.Models.MainModels
{
    public class Report : IIdentifier
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }

        public DateTime ReportedAt { get; set; }
        
        public DateTime FinishedAt { get; set; }
        
        public bool IsScheduled { get; set; }
        
        public string Description { get; set; }

        public DeforestState State { get; set; }
        
        public Account Account { get; set; }
        
        public List<Contributor> Contributors { get; set; }
        
        public Schedule Schedule { get; set; }
    }
}
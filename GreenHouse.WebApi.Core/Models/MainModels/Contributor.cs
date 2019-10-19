using System;
using GreenHouse.Core.Models.Tools;

namespace GreenHouse.Core.Models.MainModels
{
    public class Contributor : IIdentifier
    {
        public Guid Id { get; set; }
        
        public Guid ReportId { get; set; } 

        public Guid UserId { get; set; } 
        
        public DateTime LastUpdated { get; set; }
        
        public Report Report { get; set; }
        
        public Account ContributorAccount { get; set; }
    }
}
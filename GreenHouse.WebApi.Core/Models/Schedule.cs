using System;
using GreenHouse.Core.Tools;

namespace GreenHouse.Core.Models
{
    public class Schedule : IIdentifier
    {
        public Guid Id { get; set; }
        
        public Guid ReportId { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime FinishDate { get; set; }
        public Report Report { get; set; }
    }
}
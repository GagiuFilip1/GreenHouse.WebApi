using System;
using GreenHouse.Core.Models.Tools;

namespace GreenHouse.Core.Models.MainModels
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
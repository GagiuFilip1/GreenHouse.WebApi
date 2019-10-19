using System;
using GreenHouse.Core.Models.Enums;
using GreenHouse.Core.Models.Tools;

namespace GreenHouse.Core.Models.MainModels
{
    public class Account : IIdentifier
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public AccountType Type { get; set; }
    }
}
using System;

namespace GreenHouse.Core.Models.Tools
{
    public interface IIdentifier
    {
        Guid Id { get; set; }
    }
}
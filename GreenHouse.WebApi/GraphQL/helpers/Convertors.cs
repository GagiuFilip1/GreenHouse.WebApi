using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace GreenHouse.GraphQL.helpers
{
    public static class Convertors
    {
        public static ValueConverter<List<string>, string> ListOfStrings { get; } = new ValueConverter<List<string>, string>(
            v => v == null || !v.Any() ? null : JsonConvert.SerializeObject(v),
            v => v == null ? null : JsonConvert.DeserializeObject<List<string>>(v));
    }
}
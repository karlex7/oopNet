using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.MODEL
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Country
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string CountryName { get; set; }

        [JsonProperty("alternate_name")]
        public object AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }
        public int GamesDraw { get; set; } = 0;
        public int GamesWins { get; set; } = 0;
        public int GamesLoses { get; set; } = 0;
        public int Goals { get; set; } = 0;
        public int GoalsReceived { get; set; } = 0;
    }

    public partial class Country
    {
        public static List<Country> FromJson(string json) => JsonConvert.DeserializeObject<List<Country>>(json, ClassLibrary.MODEL.ConverterCountry.Settings);
    }

    public static class SerializeCountry
    {
        public static string ToJson(this List<Country> self) => JsonConvert.SerializeObject(self, ClassLibrary.MODEL.ConverterCountry.Settings);
    }

    internal static class ConverterCountry
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

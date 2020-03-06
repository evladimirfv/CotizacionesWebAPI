using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;




using System.Globalization;

using Newtonsoft.Json.Converters;


namespace CotizacionesWebAPI.Models
{
 
    public partial class WelcomeModel
    {
        [JsonProperty("result")]
        public Result Result { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }

    public partial class WelcomeModel
    {
        public static WelcomeModel FromJson(string json) => JsonConvert.DeserializeObject<WelcomeModel>(json, CotizacionesWebAPI.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this WelcomeModel self) => JsonConvert.SerializeObject(self, CotizacionesWebAPI.Models.Converter.Settings);
    }

    internal static class Converter
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

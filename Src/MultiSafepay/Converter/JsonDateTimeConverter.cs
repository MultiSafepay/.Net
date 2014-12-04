using Newtonsoft.Json.Converters;

namespace MultiSafepay.Converter
{
    /// <summary>
    /// The MultiSafepay API requires dates to be submitted in a particular format
    /// </summary>
    public class JsonDateTimeConverter : IsoDateTimeConverter
    {
        public JsonDateTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}

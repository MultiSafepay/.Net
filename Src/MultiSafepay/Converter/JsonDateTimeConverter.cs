using Newtonsoft.Json.Converters;

namespace MultiSafepay.Converter
{
    public class JsonDateTimeConverter : IsoDateTimeConverter
    {
        public JsonDateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}

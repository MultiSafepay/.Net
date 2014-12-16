using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MultiSafepay.Model
{
    public class CustomField
    {
        public CustomField(string name, CustomFieldType type)
        {
            Name = name;
            Type = type;
        }

        public CustomField(string name, StandardCustomField type)
        {
            Name = name;
            StandardType = type;
        }

        [JsonProperty("standard_type"), JsonConverter(typeof(StringEnumConverter))]
        public StandardCustomField? StandardType { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
        public CustomFieldType Type { get; set; }
        [JsonProperty("save_value")]
        public bool SaveValue { get; set; }
        [JsonProperty("default")]
        public string DefaultValue { get; set; }
        [JsonProperty("description_top")]
        public FieldDescription DescriptionTop { get; set; }
        [JsonProperty("description_right")]
        public FieldDescription DescriptionRight { get; set; }
        [JsonProperty("description_bottom")]
        public FieldDescription DescriptionBottom { get; set; }
        [JsonProperty("area_restrictions")]
        public string AreaRestrictions { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}

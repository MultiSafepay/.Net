using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TaxTables
    {
        [JsonProperty("default")]//@TODO - Change in mayor update. Default should be an array as can be settled per countries.
        public TaxTable DefaultTaxTable { get; set; }
        [JsonProperty("alternate")]
        public IList<TaxTable> AlternateTaxTables { get; set; }
    }
}
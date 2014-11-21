using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TaxTables
    {
        [JsonProperty("default")]
        public TaxTable DefaultTaxTable { get; set; }
        [JsonProperty("alternate")]
        public IList<TaxTable> AlternateTaxTables { get; set; }
    }
}
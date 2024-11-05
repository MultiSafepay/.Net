using System;
using System.Collections.Generic;

namespace MultiSafepay.Model.Transactions
{
    public class TransactionsFilter
    {
        public int? SideId { get; set; }
        public string DebitCredit { get; set; }
        public DateTime CreatedUntil { get; set; }
        public DateTime CompletedFrom { get; set; }
        public DateTime CompletedUntil { get; set; }
        public DateTime CreatedFrom { get; set; }
        public string PaymentMethod { get; set; }
        public List<TypesEnum> Type { get; set; }
        public List<StatusEnum> Status { get; set; }
        public List<FinancialStatusEnum> FinancialStatus { get; set; }

        //Pager
        public int? Limit { get; set; }
        public string After { get; set; }
        public string Before { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ReadersApi.Models
{
    public partial class TblBookPayment
    {
        public int PaymentId { get; set; }
        public string TransactionId { get; set; }
        public int PurchaseId { get; set; }
        public int? BookAmount { get; set; }
        public DateTime? BookPaymentDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

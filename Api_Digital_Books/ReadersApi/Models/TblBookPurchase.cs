using System;
using System.Collections.Generic;

#nullable disable

namespace ReadersApi.Models
{
    public partial class TblBookPurchase
    {
        public int PurchaseId { get; set; }
        public string OrderNo { get; set; }
        public int? BookId { get; set; }
        public int? ReaderId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

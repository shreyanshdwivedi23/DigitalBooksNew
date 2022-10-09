using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public bool? IsRefund { get; set; }
                
        [NotMapped]
        public TblLogin tblLoginObj { get; set; } = new TblLogin();
        [NotMapped]
        public TblBook tblBookObj { get; set; } = new TblBook();
    }
}

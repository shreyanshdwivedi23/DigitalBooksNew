using System;
using System.Collections.Generic;

#nullable disable

namespace ReadersApi.Models
{
    public partial class TblBook
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookCategory { get; set; }
        public string BookImage { get; set; }
        public string BookPrice { get; set; }
        public string BookPublisher { get; set; }
        public string BookContent { get; set; }
        public bool? BookIsActive { get; set; }
        public int? BookCreatedBy { get; set; }
        public DateTime? BookCreatedDate { get; set; }
        public DateTime? BookReleasedDate { get; set; }
        public bool? BookIsDelete { get; set; }
        public bool? BookIsBlock { get; set; }
        public DateTime? BookModifiedDate { get; set; }
        public int? BookModifiedBy { get; set; }
        public string BookAuthor { get; set; }
    }
}

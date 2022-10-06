using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalBooksApi.Models
{
    public partial class TblLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public string UserEmail { get; set; }
        public string UserFullname { get; set; }
        public int? UserMobileNo { get; set; }
    }
}

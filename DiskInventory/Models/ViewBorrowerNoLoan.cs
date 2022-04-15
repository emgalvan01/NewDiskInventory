using System;
using System.Collections.Generic;

#nullable disable

namespace DiskInventory.Models
{
    public partial class ViewBorrowerNoLoan
    {
        public int BorrowerId { get; set; }
        public string Lname { get; set; }
        public string Fname { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DiskInventory.Models
{
    public partial class Borrower
    {
        public Borrower()
        {
            DiskHasBorrowers = new HashSet<DiskHasBorrower>();
        }

        public int BorrowerId { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        public string Lname { get; set; }
        [Required(ErrorMessage = "Please enter a phone number.")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<DiskHasBorrower> DiskHasBorrowers { get; set; }
    }
}

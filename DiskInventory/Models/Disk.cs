using System;
using System.Collections.Generic;

#nullable disable

namespace DiskInventory.Models
{
    public partial class Disk
    {
        public Disk()
        {
            DiskHasBorrowers = new HashSet<DiskHasBorrower>();
        }

        public int DiskId { get; set; }
        public string DiskName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int StatusId { get; set; }
        public int DiskTypeId { get; set; }
        public int GenreId { get; set; }

        public virtual DiskType DiskType { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<DiskHasBorrower> DiskHasBorrowers { get; set; }
    }
}

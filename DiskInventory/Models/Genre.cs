using System;
using System.Collections.Generic;

#nullable disable

namespace DiskInventory.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Disks = new HashSet<Disk>();
        }

        public int GenreId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Disk> Disks { get; set; }
    }
}

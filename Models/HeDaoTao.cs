using System;
using System.Collections.Generic;

#nullable disable

namespace QLSV.Models
{
    public partial class HeDaoTao
    {
        public HeDaoTao()
        {
            Lops = new HashSet<Lop>();
        }

        public string MaHdt { get; set; }
        public string TenHdt { get; set; }
        public byte ThoiGian { get; set; }

        public virtual ICollection<Lop> Lops { get; set; }
    }
}

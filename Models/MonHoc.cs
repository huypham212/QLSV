using System;
using System.Collections.Generic;

#nullable disable

namespace QLSV.Models
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            Diems = new HashSet<Diem>();
        }

        public string MaMh { get; set; }
        public string TenMh { get; set; }
        public string MaCn { get; set; }
        public byte SoTc { get; set; }

        public virtual ChuyenNganh MaCnNavigation { get; set; }
        public virtual ICollection<Diem> Diems { get; set; }
    }
}

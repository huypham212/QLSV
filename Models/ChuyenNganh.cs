using System;
using System.Collections.Generic;

#nullable disable

namespace QLSV.Models
{
    public partial class ChuyenNganh
    {
        public ChuyenNganh()
        {
            MonHocs = new HashSet<MonHoc>();
        }

        public string MaCn { get; set; }
        public string TenCn { get; set; }
        public string MaKhoa { get; set; }

        public virtual Khoa MaKhoaNavigation { get; set; }
        public virtual ICollection<MonHoc> MonHocs { get; set; }
    }
}

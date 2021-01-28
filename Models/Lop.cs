using System;
using System.Collections.Generic;

#nullable disable

namespace QLSV.Models
{
    public partial class Lop
    {
        public Lop()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public byte SiSo { get; set; }
        public string MaKhoa { get; set; }
        public string MaHdt { get; set; }
        public short? NamBatDau { get; set; }

        public virtual HeDaoTao MaHdtNavigation { get; set; }
        public virtual Khoa MaKhoaNavigation { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}

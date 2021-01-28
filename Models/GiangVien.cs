using System;
using System.Collections.Generic;

#nullable disable

namespace QLSV.Models
{
    public partial class GiangVien
    {
        public GiangVien()
        {
            Diems = new HashSet<Diem>();
        }

        public string MaGv { get; set; }
        public string TenGv { get; set; }
        public string Gioitinh { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string MaKhoa { get; set; }
        public string MaCv { get; set; }

        public virtual ChucVu MaCvNavigation { get; set; }
        public virtual Khoa MaKhoaNavigation { get; set; }
        public virtual ICollection<Diem> Diems { get; set; }
    }
}

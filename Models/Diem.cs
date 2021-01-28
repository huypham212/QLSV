using System;
using System.Collections.Generic;

#nullable disable

namespace QLSV.Models
{
    public partial class Diem
    {
        public string MaSv { get; set; }
        public string MaMh { get; set; }
        public string MaGv { get; set; }
        public decimal DiemCc { get; set; }
        public decimal DiemTx { get; set; }
        public decimal DiemGk { get; set; }
        public decimal DiemThi { get; set; }
        public decimal DiemTb { get; set; }

        public virtual GiangVien MaGvNavigation { get; set; }
        public virtual MonHoc MaMhNavigation { get; set; }
        public virtual SinhVien MaSvNavigation { get; set; }
    }
}

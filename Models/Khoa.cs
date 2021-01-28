using System;
using System.Collections.Generic;
using AutoMapper;

#nullable disable

namespace QLSV.Models
{
    public partial class Khoa
    {

        public Khoa()
        {
            ChuyenNganhs = new HashSet<ChuyenNganh>();
            GiangViens = new HashSet<GiangVien>();
            Lops = new HashSet<Lop>();
        }

        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }

        public virtual ICollection<ChuyenNganh> ChuyenNganhs { get; set; }
        public virtual ICollection<GiangVien> GiangViens { get; set; }
        public virtual ICollection<Lop> Lops { get; set; }
    }
}

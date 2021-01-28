using System;

namespace QLSV.DTOs
{
    public partial class SinhVienDTO
    {
        public string MaSv { get; set; }
        public string TenSv { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string MaLop { get; set; }
        public int? NamNhapHoc { get; set; }
        public string HocPhi { get; set; }
        public string TinhTrang { get; set; }
        public string GhiChu { get; set; }
    }
}

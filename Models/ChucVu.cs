using System;
using System.Collections.Generic;

#nullable disable

namespace QLSV.Models
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            GiangViens = new HashSet<GiangVien>();
        }

        public string MaCv { get; set; }
        public string TenCv { get; set; }

        public virtual ICollection<GiangVien> GiangViens { get; set; }
    }
}

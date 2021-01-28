using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLSV.Models;

namespace QLSV.Service
{
    public interface ISinhVienService
    {
        IEnumerable<SinhVien> GetSinhViens();

        SinhVien GetSinhVienByMaSV(string masv);

        public void CreateSinhVien(SinhVien sv);

        public void UpdateSinhVien(string masv);

        public void DeleteSinhVien(string masv);

        bool SaveChange();

    }
}

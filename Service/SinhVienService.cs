using QLSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSV.Service
{
    public class SinhVienService : ISinhVienService
    {
        public readonly QLSVContext _context;

        public SinhVienService(QLSVContext context)
        {
            _context = context;
        }

        public SinhVien GetSinhVienByMaSV(string masv)
        {
            return _context.SinhViens.FirstOrDefault(ma => ma.MaSv == masv);
        }

        public IEnumerable<SinhVien> GetSinhViens()
        {
            //return _context.SinhViens.ToList();

            var list = from sv in _context.SinhViens
                       join lop in _context.Lops on sv.MaLop equals lop.MaLop
                       join khoa in _context.Khoas on lop.MaKhoa equals khoa.MaKhoa
                       select new { MaSv = sv.MaSv, TenSv = sv.TenSv, TenKhoa = khoa.TenKhoa };
            
            return (IEnumerable<SinhVien>)list.ToList();
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateSinhVien(SinhVien sv)
        {
            _context.SinhViens.Add(sv);
        }

        public void UpdateSinhVien(string masv) { }

        public void DeleteSinhVien(string masv)
        {
            _context.SinhViens.Remove(GetSinhVienByMaSV(masv));
        }
    }
}

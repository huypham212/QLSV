using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLSV.Models;

namespace QLSV.Service
{
    public class KhoaService : IKhoaService
    {
        private readonly QLSVContext _context;
        
        public KhoaService(QLSVContext context)
        {
            _context = context;
        }

        public void CreateKhoas(Khoa khoa)
        {
            _context.Khoas.Add(khoa);
        }

        public void DeleteKhoa(string maKhoa)
        {
            _context.Khoas.Remove(GetKhoasByMaKhoa(maKhoa));
        }

        public IEnumerable<Khoa> GetKhoas()
        {
            return _context.Khoas.ToList();
        }

        public Khoa GetKhoasByMaKhoa(string maKhoa)
        {
            return _context.Khoas.FirstOrDefault(ma => ma.MaKhoa == maKhoa);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateKhoa(Khoa khoa) { }
    }
}

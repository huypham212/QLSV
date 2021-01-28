using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLSV.Models;
using Dapper;
using System.Data.SqlClient;

namespace QLSV.Service
{

    public interface IKhoaService
    {
        bool SaveChange();

        IEnumerable<Khoa> GetKhoas();

        Khoa GetKhoasByMaKhoa(string maKhoa);

        public void CreateKhoas(Khoa khoa);

        public void UpdateKhoa(Khoa khoa);

        public void DeleteKhoa(string maKhoa);
    }
}

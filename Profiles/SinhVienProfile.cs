using AutoMapper;
using QLSV.Models;
using QLSV.DTOs;

namespace QLSV.Profiles
{
    public class SinhVienProfile : Profile
    {
        public SinhVienProfile()
        {
            CreateMap<SinhVien, SinhVienDTO>();
            CreateMap<SinhVienDTO, SinhVien>();
        }
    }
}

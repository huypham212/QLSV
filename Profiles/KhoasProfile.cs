using AutoMapper;
using QLSV.DTOs;
using QLSV.Models;

namespace QLSV.Profiles
{
    public class KhoasProfile : Profile
    {
        public KhoasProfile()
        {
            //Source --> Target
            CreateMap<Khoa, KhoaDTO>();
            CreateMap<KhoaDTO, Khoa>();
        }
    }
}

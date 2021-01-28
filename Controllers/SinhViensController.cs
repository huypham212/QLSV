using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSV.DTOs;
using QLSV.Models;
using QLSV.Service;
using AutoMapper; 

namespace QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhViensController : ControllerBase
    {
        private readonly ISinhVienService _service;
        private readonly IMapper _mapper;

        public SinhViensController(ISinhVienService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/SinhVien
        [HttpGet]
        public ActionResult<IEnumerable<SinhVienDTO>> GetSinhViens()
        {
            var sv_items = _service.GetSinhViens();

            return Ok(_mapper.Map<IEnumerable<SinhVienDTO>>(sv_items));
        }

        //GET: api/SinhVien/masv
        [HttpGet("{MaSV}")]
        public ActionResult<SinhVienDTO> GetSinhVienByMaSV(string masv)
        {
            var ma = _service.GetSinhVienByMaSV(masv);
            if(ma != null)
            {
                return Ok(_mapper.Map<SinhVienDTO>(ma));
            }

            return NotFound();
        }

        //POST: api/SinhViens
        [HttpPost]
        public ActionResult<SinhVienDTO> CreateSinhVien(SinhVienDTO svDTO)
        {
            var new_sv = _mapper.Map<SinhVien>(svDTO);

            _service.CreateSinhVien(new_sv);
            _service.SaveChange();

            return Ok(new_sv);
        }

        //PUT: api/SinhViens/masv
        [HttpPut("{MaSV}")]
        public ActionResult<SinhVienDTO> UpdateSinhVien(string masv, SinhVienDTO svDTO)
        {
            var eidt_sv = _service.GetSinhVienByMaSV(masv);

            if(eidt_sv == null)
            {
                return NotFound();
            }

            _mapper.Map(svDTO, eidt_sv);

            _service.UpdateSinhVien(masv);

            _service.SaveChange();

            return Ok();
        }
    }
}

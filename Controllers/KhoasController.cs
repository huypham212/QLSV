using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLSV.DTOs;
using QLSV.Models;
using QLSV.Service;

namespace QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoasController : ControllerBase
    {
        private readonly IKhoaService _service;
        private readonly IMapper _mapper;

        public KhoasController(IKhoaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Khoas
        [HttpGet]
        public ActionResult<IEnumerable<KhoaDTO>> GetKhoas()
        {
            var khoaItems = _service.GetKhoas();

            return Ok(_mapper.Map<IEnumerable<KhoaDTO>>(khoaItems));
        }

        // GET: api/Khoas/5
        [HttpGet("{maKhoa}")]
        public ActionResult<KhoaDTO> GetKhoasByMaKhoa(string maKhoa)
        {
            var khoa = _service.GetKhoasByMaKhoa(maKhoa);

            if (khoa != null)
            {
                return Ok(_mapper.Map<KhoaDTO>(khoa));
            }

            return NotFound();
        }

        // POST: api/Khoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<KhoaDTO> CreateKhoas(KhoaDTO khoaDTO)
        {
            var new_khoa = _mapper.Map<Khoa>(khoaDTO);
            _service.CreateKhoas(new_khoa);
            _service.SaveChange();

            return Ok(new_khoa);
        }

        // PUT: api/Khoas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{maKhoa}")]
        public ActionResult<KhoaDTO> UpdateKhoa(string maKhoa, KhoaDTO khoaDTO)
        {
            var edit_khoa = _service.GetKhoasByMaKhoa(maKhoa);
            if (edit_khoa == null)
            {
                return NotFound();
            }
            _mapper.Map(khoaDTO, edit_khoa);

            _service.UpdateKhoa(edit_khoa);

            _service.SaveChange();

            return Ok();
        }

        // DELETE: api/Khoas/5
        [HttpDelete("{maKhoa}")]
        public ActionResult DeleteKhoa(string maKhoa)
        {
            var del_khoa = _service.GetKhoasByMaKhoa(maKhoa);
            if(del_khoa == null)
            {
                return NotFound();
            }

            _service.DeleteKhoa(maKhoa);
            _service.SaveChange();

            return Ok();
        }
    }
}

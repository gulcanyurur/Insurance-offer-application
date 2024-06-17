using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoveragesController : ControllerBase
    {
        private readonly ICoverageService _coverageService;

        public CoveragesController(ICoverageService coverageService)
        {
            _coverageService = coverageService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var coverage = _coverageService.GetById(id);
            if (coverage == null)
                return NotFound(new { Message = "Teminat bulunamadı." });

            return Ok(new { Message = "Teminat getirildi.", Data = coverage });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var coverages = _coverageService.GetAll();
            return Ok(new { Message = "Teminatlar getirildi.", Data = coverages });
        }

        [HttpPost]
        public IActionResult Add([FromBody] Coverage coverage)
        {
            try
            {
                var message = _coverageService.Add(coverage);
                return CreatedAtAction(nameof(GetById), new { id = coverage.CoverageID }, new { Message = message, Data = coverage });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Coverage coverage)
        {
            try
            {
                if (id != coverage.CoverageID)
                    return BadRequest(new { Message = "ID uyuşmazlığı." });

                var message = _coverageService.Update(coverage);
                return Ok(new { Message = message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var coverage = _coverageService.GetById(id);
            if (coverage == null)
                return NotFound(new { Message = "Teminat bulunamadı." });

            _coverageService.Delete(coverage);
            return Ok(new { Message = "Teminat başarıyla silindi." });
        }
    }
}



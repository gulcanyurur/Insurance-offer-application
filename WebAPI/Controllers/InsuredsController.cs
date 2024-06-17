using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredsController : ControllerBase
    {
        private readonly IInsuredService _insuredService;

        public InsuredsController(IInsuredService insuredService)
        {
            _insuredService = insuredService;
        }

        [HttpGet("byTC/{tckn}")]
        public IActionResult GetByTCKN(string tckn)
        {
            try
            {
                var insured = _insuredService.GetByTCKN(tckn);
                return Ok(new { Message = "Sigortalı getirildi.", Data = insured });
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var insured = _insuredService.GetById(id);
                return Ok(new { Message = "Sigortalı getirildi.", Data = insured });
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Insured insured)
        {
            try
            {
                var message = _insuredService.Add(insured);
                return CreatedAtAction(nameof(GetById), new { id = insured.InsuredID }, new { Message = message, Data = insured });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "";
                return BadRequest(new { Message = $"{ex.Message} {innerException}" });
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Insured insured)
        {
            try
            {
                if (id != insured.InsuredID)
                    return BadRequest(new { Message = "ID uyuşmazlığı." });

                var message = _insuredService.Update(insured);
                return Ok(new { Message = message });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "";
                return BadRequest(new { Message = $"{ex.Message} {innerException}" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var insured = _insuredService.GetById(id);
                if (insured == null)
                {
                    return NotFound(new { Message = "Sigortalı bulunamadı." });
                }
                var message = _insuredService.Delete(insured);
                return Ok(new { Message = message });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "";
                return NotFound(new { Message = $"{ex.Message} {innerException}" });
            }
        }
    }
}










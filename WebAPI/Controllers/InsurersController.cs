using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurersController : ControllerBase
    {
        private readonly IInsurerService _insurerService;

        public InsurersController(IInsurerService insurerService)
        {
            _insurerService = insurerService;
        }

        [HttpGet("byTC/{tckn}")]
        public IActionResult GetByTCKN(string tckn)
        {
            try
            {
                var insurer = _insurerService.GetByTCKN(tckn);
                return Ok(new { Message = "Sigorta ettiren getirildi.", Data = insurer });
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
                var insurer = _insurerService.GetById(id);
                return Ok(new { Message = "Sigorta ettiren getirildi.", Data = insurer });
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Insurer insurer)
        {
            try
            {
                var message = _insurerService.Add(insurer);
                return CreatedAtAction(nameof(GetById), new { id = insurer.InsurerID }, new { Message = message, Data = insurer });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "";
                return BadRequest(new { Message = $"{ex.Message} {innerException}" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Insurer insurer)
        {
            try
            {
                if (id != insurer.InsurerID)
                    return BadRequest(new { Message = "ID uyuşmazlığı." });

                var message = _insurerService.Update(insurer);
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
                var insurer = _insurerService.GetById(id);
                if (insurer == null)
                {
                    return NotFound(new { Message = "Sigorta ettiren bulunamadı." });
                }
                var message = _insurerService.Delete(insurer);
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








using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyCoveragesController : ControllerBase
    {
        private readonly IPolicyCoverageService _policyCoverageService;

        public PolicyCoveragesController(IPolicyCoverageService policyCoverageService)
        {
            _policyCoverageService = policyCoverageService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var policyCoverage = _policyCoverageService.GetById(id);
            if (policyCoverage == null)
                return NotFound(new { Message = "Poliçe teminatı bulunamadı." });

            return Ok(new { Message = "Poliçe teminatı getirildi.", Data = policyCoverage });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var policyCoverages = _policyCoverageService.GetAll();
            return Ok(new { Message = "Poliçe teminatları getirildi.", Data = policyCoverages });
        }

        [HttpPost]
        public IActionResult Add([FromBody] PolicyCoverage policyCoverage)
        {
            try
            {
                var message = _policyCoverageService.Add(policyCoverage);
                return CreatedAtAction(nameof(GetById), new { id = policyCoverage.PolicyCoverageID }, new { Message = message, Data = policyCoverage });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PolicyCoverage policyCoverage)
        {
            try
            {
                if (id != policyCoverage.PolicyCoverageID)
                    return BadRequest(new { Message = "ID uyuşmazlığı." });

                var message = _policyCoverageService.Update(policyCoverage);
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
            var policyCoverage = _policyCoverageService.GetById(id);
            if (policyCoverage == null)
                return NotFound(new { Message = "Poliçe teminatı bulunamadı." });

            _policyCoverageService.Delete(policyCoverage);
            return Ok(new { Message = "Poliçe teminatı başarıyla silindi." });
        }
    }
}

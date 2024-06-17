using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PoliciesController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var policy = _policyService.GetById(id);
            if (policy == null)
                return NotFound(new { Message = "Poliçe bulunamadı." });

            return Ok(new { Message = "Poliçe getirildi.", Data = policy });
        }

        [HttpPost]
        public IActionResult Add([FromBody] Policy policy)
        {
            try
            {
                var message = _policyService.Add(policy);
                return CreatedAtAction(nameof(GetById), new { id = policy.PolicyID }, new { Message = message, Data = policy });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Policy policy)
        {
            try
            {
                if (id != policy.PolicyID)
                    return BadRequest(new { Message = "ID uyuşmazlığı." });

                var message = _policyService.Update(policy);
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
            var policy = _policyService.GetById(id);
            if (policy == null)
                return NotFound(new { Message = "Poliçe bulunamadı." });

            _policyService.Delete(policy);
            return Ok(new { Message = "Poliçe başarıyla silindi." });
        }

        [HttpGet("exists/{insurerId}/{insuredId}")]
        public IActionResult PolicyExists(int insurerId, int insuredId)
        {
            var exists = _policyService.PolicyExists(insurerId, insuredId);
            return Ok(new { Message = "Poliçe varlığı sorgulandı.", Exists = exists });
        }

        [HttpGet("existsbydate")]
        public IActionResult PolicyExistsByDate(int insurerId, int insuredId, DateTime startDate, DateTime endDate)
        {
            var exists = _policyService.PolicyExistsByDate(insurerId, insuredId, startDate, endDate);
            return Ok(new { Message = "Tarihlerle poliçe varlığı sorgulandı.", Exists = exists });
        }
    }
}


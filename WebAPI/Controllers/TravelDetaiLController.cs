using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelDetailsController : ControllerBase
    {
        private readonly ITravelDetailService _travelDetailService;

        public TravelDetailsController(ITravelDetailService travelDetailService)
        {
            _travelDetailService = travelDetailService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _travelDetailService.Get(td => td.TravelDetailID == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _travelDetailService.GetList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] TravelDetail travelDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _travelDetailService.Add(travelDetail);
            return CreatedAtAction(nameof(Get), new { id = travelDetail.TravelDetailID }, travelDetail);
        }
    }
}

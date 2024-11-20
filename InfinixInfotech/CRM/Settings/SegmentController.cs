﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Settings;
using Services.Settings.IClass;

namespace InfinixInfotech.CRM.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        private readonly ISegmentService _segmentService;
        public SegmentController(ISegmentService segmentService) 
        {
            _segmentService = segmentService;
        }
        [HttpPost]
        [Route("InsertSegmentAsync")]
        [Authorize(Policy ="admin")]
        public async Task<IActionResult> InsertSegmentAsync([FromBody] Segment segment)
        {
            var response = await _segmentService.InsertSegmentAsync(segment);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateSegmentByIdAsync")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> UpdateSegmentByIdAsync(int id, [FromBody] Segment segment)
        {
            var response = await _segmentService.UpdateSegmentByIdAsync(id, segment);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteSegmentByIdAsync")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> DeleteSegmentByIdAsync(int id)
        {
            var response = await _segmentService.DeleteSegmentByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllSegmentAsync")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> GetAllSegmentAsync()
        {
            var response = await _segmentService.GetAllSegmentAsync();
            return Ok(response);
        }
    }
}

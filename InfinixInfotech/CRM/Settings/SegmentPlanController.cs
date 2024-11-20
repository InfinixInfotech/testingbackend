﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Settings;
using Services.Settings.IClass;

namespace InfinixInfotech.CRM.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentPlanController : ControllerBase
    {
        private readonly ISegmentPlanService _segmentPlan;
        public SegmentPlanController(ISegmentPlanService segmentPlan) 
        { 
            _segmentPlan = segmentPlan;
        }
        [HttpPost]
        [Route("InsertSegmentPlanAsync")]
        [Authorize(Policy ="admin")]
        public async Task<IActionResult> InsertSegmentPlanAsync(SegmentPlan segmentPlan)
        {
            var response = await _segmentPlan.InsertSegmentPlanAsync(segmentPlan);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateSegmentPlanByIdAsync")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> UpdateSegmentPlanByIdAsync(int id, SegmentPlan segmentPlan)
        {
            var response = await _segmentPlan.UpdateSegmentPlanByIdAsync(id, segmentPlan);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteSegmentPlanByIdAsync")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> DeleteSegmentPlanByIdAsync(int id)
        {
            var response = await _segmentPlan.DeleteSegmentPlanByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllSegmentPlanAsync")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> GetAllSegmentPlanAsync()
        {
            var response = await _segmentPlan.GetAllSegmentPlanAsync();
            return Ok(response);
        }
    }
}
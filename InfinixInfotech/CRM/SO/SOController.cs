﻿using InfinixInfotech.CRM.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Settings;
using Models.SO;
using Services.SO.IClass;

namespace InfinixInfotech.CRM.SO
{
    [Route("api/[controller]")]
    [ApiController]
    public class SOController : ControllerBase
    {
        private readonly ISOService _sOService;
        private readonly HomeController _homeController;
        public SOController(ISOService sOService, HomeController homeController)
        {
            _sOService = sOService;
            _homeController = homeController;

        }
        [HttpGet]
        [Route("GetAllSO")]
        [Authorize(Policy = ("AdminOrUser"))]
        public async Task<IActionResult> GetAllSO(string apiType, string accessType)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _sOService.GetAllSO(apiType, accessType, grpName);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        [Route("InsertSO")]
        [Authorize(Policy = ("AdminOrUser"))]
        public async Task<IActionResult> InsertSO([FromBody] So sO)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _sOService.InsertSO(sO, grpName);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        [Route("UpdateSO")]
        [Authorize(Policy = ("AdminOrUser"))]
        public async Task<IActionResult> UpdateSO([FromBody] So sO)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _sOService.UpdateSO(sO, grpName);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [Route("DeleteSO")]
        [Authorize(Policy = ("AdminOrUser"))]
        public async Task<IActionResult> DeleteSO(int id, string apiType, string accessType)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _sOService.DeleteSO(id, apiType, accessType, grpName);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        [Route("GetSOById")]
        [Authorize(Policy = ("AdminOrUser"))]
        public async Task<IActionResult> GetSOById(int id, string apiType, string accessType)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _sOService.GetSOById(id, apiType, accessType, grpName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
    }
}
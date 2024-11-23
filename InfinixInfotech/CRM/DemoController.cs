
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Demo;
using Services.Common.Class;
using Services.Common.IClass;
using Services.Demo.IClass;

namespace InfinixInfotech.CRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ISecurityService _security;
        private readonly IDemoService _service;
        public DemoController(ISecurityService security , IDemoService service)
        {
            _security = security;
            _service = service;
        }
        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            return Ok("Hello from india");
        }
        [HttpGet("Encrypt")]
        
        public IActionResult Encrypt(string data)
        {
            return Ok(_security.Encryption(data));
        }

        [HttpGet("Decrypt")]
        public IActionResult Decrypt(string encryptedData)
        {
            return Ok(_security.Decryption(encryptedData));
        }
        

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Demos>>> GetAll()
        {
            var demos = await _service.GetAllAsync();
            return Ok(demos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Demos>> GetById(int id)
        {
            var demo = await _service.GetByIdAsync(id);
            if (demo == null)
                return NotFound();

            return Ok(demo);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Demos demo)
        {
            await _service.AddAsync(demo);
            return CreatedAtAction(nameof(GetById), new { id = demo.Id }, demo);
        }
    }
}

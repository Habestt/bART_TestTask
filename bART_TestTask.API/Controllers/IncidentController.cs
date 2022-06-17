using bART_TestTask.BLL.DTOs;
using bART_TestTask.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bART_TestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        public readonly IIncidentService _incidentService;
        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _incidentService.GetAllAsync());
        }

        [HttpPost("create")]
        public async Task Create([FromBody] IncidentDTO entity)
        {
            await _incidentService.AddAsync(entity);
        }

        [HttpPost("createForAccount")]
        public async Task CreateForAcc([FromBody] IncidentForAccDTO entity)
        {
            await _incidentService.AddForAccAsync(entity);
        }
    }
}

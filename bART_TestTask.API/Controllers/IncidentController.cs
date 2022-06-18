using bART_TestTask.BLL.DTOs;
using bART_TestTask.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace bART_TestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;
        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var incedents = await _incidentService.GetAllAsync();
            if (incedents == null)
            {
                return NotFound();
            }
            return Ok(incedents);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] IncidentDTO entity)
        {
            try
            {
                await _incidentService.AddAsync(entity);
            }
            catch (ArgumentException ex)
            { 
                return BadRequest(ex.Message);
            }
            return Ok(new { Message = "Incident was added successfully" });

        }

        [HttpPost("createForAccount/{accountName}")]
        public async Task<IActionResult> CreateForAcc([FromBody] IncidentForAccDTO entity, string accountName)
        {
            try
            {
                await _incidentService.AddForAccAsync(entity, accountName);
            }
            catch(ArgumentException ex)
            {

                if (ex.Message == "account was not found")
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return BadRequest(ex.Message);
                }
                    
            }
            return Ok(new { Message = "Incident was added successfully" });
        }
    }
}

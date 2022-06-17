using bART_TestTask.BLL.DTOs;
using bART_TestTask.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bART_TestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactService.GetAllAsync();
            if (contacts == null)
            {
                return NotFound();
            }
            return Ok(contacts);
        }

        [HttpGet("getByEmail/{contactEmail}")]
        public async Task<IActionResult> GetByEmail(string contactEmail)
        {
            try
            {
                return Ok(await _contactService.GetByEmailAsync(contactEmail));
            }
            catch (ArgumentException ex)
            {                
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ContactDTO entity)
        {
            try
            {
                await _contactService.AddAsync(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { Message = "Contact was added successfully" });
        }

        [HttpPost("CreateOrUpdate/{contactEmail}")]
        public async Task CreateOrUpdateForAcc([FromBody] ContactForAccDTO entity, string contactEmail)
        {            
            await _contactService.CreateOrUpdateByEmailAsync(entity, contactEmail);
        }
    }
}

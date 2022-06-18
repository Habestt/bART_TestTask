using bART_TestTask.BLL.DTOs;
using bART_TestTask.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bART_TestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;            
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _accountService.GetAllAsync();
            if (accounts == null)
            {
                return NotFound();
            }
            return Ok(accounts);
        }

        [HttpGet("getByName/{accountName}")]
        public async Task<IActionResult> GetByName(string accountName)
        {            
            try
            {
                return Ok( await _accountService.GetByNameAsync(accountName));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AccountDTO entity)
        {
            try
            {
                await _accountService.AddAsync(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { Message = "Account was added successfully" });
        }
    }
}

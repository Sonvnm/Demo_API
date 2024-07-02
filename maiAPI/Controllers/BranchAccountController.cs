using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Repositories.BranchAccountRepo;
using System.Diagnostics.Metrics;

namespace maiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchAccountController : ControllerBase
    {
        private readonly BranchAccountRepo repository = new BranchAccountRepo();
        
        [HttpPost("Login")]
        public IActionResult LoginAccount(string email, string password)
        {
            try
            {
                BranchAccount member = repository.Login(email, password);

                if (member != null)
                {
                    return Ok(member);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SqlException)
            {
                return StatusCode(500, "Internal Server Exception");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll")]
        public ActionResult<IList<BranchAccount>> GetAccounts()
        {
            IList<BranchAccount> accounts = repository.GetAccounts();
            return Ok(accounts);
        }
    }
}

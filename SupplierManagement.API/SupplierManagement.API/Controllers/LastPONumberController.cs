using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplierManagement.Data.DBContext;
using SupplierManagement.Data.Models;

namespace SupplierManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LastPONumberController : ControllerBase
    {
        private readonly SupplierManagementDBContext _context;

        public LastPONumberController(SupplierManagementDBContext _context)
        {
           this._context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<LastPONumber>> GetLastPONumber()
        {
            var lastPONumber = await _context.LastPONumbers.FirstOrDefaultAsync();
           
            if(lastPONumber == null)
            {
                return NotFound();
            }

            return Ok(lastPONumber);

            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLastPONumber(LastPONumber lastNumber)
        {
            var lastPONumber = await _context.LastPONumbers.FirstOrDefaultAsync();
            if (lastPONumber == null)
            {   
                _context.LastPONumbers.Add(lastNumber);
            }
            else
            {
                lastPONumber.LastNumber = lastNumber.LastNumber;
            }

            await _context.SaveChangesAsync();
            return Ok(lastPONumber);
        }
    }
}

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
        public async Task<ActionResult<long>> GetLastPONumber()
        {
            var lastPONumber = await _context.LastPONumbers.FirstOrDefaultAsync();
            return lastPONumber?.LastNumber ?? 1000;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLastPONumber(long newLastNumber)
        {
            var lastPONumber = await _context.LastPONumbers.FirstOrDefaultAsync();
            if (lastPONumber == null)
            {
                lastPONumber = new LastPONumber { LastNumber = newLastNumber };
                _context.LastPONumbers.Add(lastPONumber);
            }
            else
            {
                lastPONumber.LastNumber = newLastNumber;
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

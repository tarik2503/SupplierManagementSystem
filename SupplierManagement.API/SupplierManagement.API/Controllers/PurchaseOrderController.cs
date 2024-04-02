using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierManagement.API.IRepository;
using SupplierManagement.Data.Models;
using System.Security.Claims;

namespace SupplierManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrder _purchaseOrder;

        public PurchaseOrderController(IPurchaseOrder _purchaseOrder)
        {
           this._purchaseOrder = _purchaseOrder;
        }

        [HttpGet]
        public async Task<ActionResult> GetPurchaseOrders()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(await _purchaseOrder.GetPurchaseOrders(userId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrder([FromBody] PurchaseOrder purchaseOrder)
        {
            try
            {
                if (purchaseOrder == null)
                {
                    return BadRequest();
                }
              
                purchaseOrder.Id = Guid.NewGuid();

                var addProduct = await _purchaseOrder.AddPurchaseOrder(purchaseOrder);

                return Ok(addProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while adding data to the database");
            }
        }

    }
}

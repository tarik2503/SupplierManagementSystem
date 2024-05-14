using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SupplierManagement.API.Helpers;
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

                bool addProduct = await _purchaseOrder.AddPurchaseOrder(purchaseOrder);
                if (!addProduct)
                {
                    return BadRequest(new
                    {
                        Message = "Oops! Error while inserting Purchase Order"
                    });                   
                }

                return Ok(new
                {
                    Message = "Purchase Order Inserted Successfully!"
                });

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while adding data to the database");
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<PurchaseOrder>> GetPurchaseOrder(Guid id)
        {
            try
            {
                var result = await _purchaseOrder.GetPurchaseOrder(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdatePurchaseOrder([FromRoute] Guid id,  PurchaseOrder purchaseOrder)
        {
            var updatePurchaseOrder = await _purchaseOrder.GetPurchaseOrder(id);
            if (updatePurchaseOrder == null)
            {
                return NotFound();
            }

            purchaseOrder.Id = updatePurchaseOrder.Id;
            bool updatedPurchaseOrder = await _purchaseOrder.UpdatePurchaseOrder(purchaseOrder);
            if (!updatedPurchaseOrder)
            {
                return BadRequest(new
                {
                    Message = "Oops! Error while updating Purchase Order"
                });
            }

            return Ok(new
            {
                Message = "Purchase Order Updated Successfully!"
            });


        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult<PurchaseOrder>> DeletePurchaseOrder(Guid id)
        {
            try
            {
                var purchaseOrderToDelete = await _purchaseOrder.GetPurchaseOrder(id);

                if (purchaseOrderToDelete == null)
                {
                    return NotFound($"Purchase Order with ID = {id} not found");
                }

                bool deletedPurchaseOrder = await _purchaseOrder.DeletePurchaseOrder(id);
                if (!deletedPurchaseOrder)
                {
                    return BadRequest();
                }

                return Ok(purchaseOrderToDelete);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting Data");
            }
        }

    }
}

using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplier _supplier;

        public SupplierController(ISupplier _supplier)
        {
            this._supplier = _supplier;
        }

        [HttpGet]
        public async Task<ActionResult> GetSuppliers()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(await _supplier.GetSuppliers(userId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<Supplier>> GetSupplier(Guid id)
        {
            try
            {
                var result = await _supplier.GetSupplier(id);

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

        [Consumes("multipart/form-data")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> AddSupplier(IFormFile image, IFormCollection formCollection)
        {
            try
            {
                var supplier = JsonConvert.DeserializeObject<Supplier>(formCollection["supplier"]);
                if (supplier == null)
                {
                    return BadRequest();
                }
               
                if (image.Length > 0)
                {                   
                    supplier.ImgPath =  UploadFile.uploadImageFile(image);                   
                    supplier.Id = Guid.NewGuid();
                    supplier.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    var addSupplier = await _supplier.AddSupplier(supplier);
                    return Ok(addSupplier);
                }
  
                return BadRequest("Image Not Found");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while adding data to the database");
            }
        }

        [Consumes("multipart/form-data")]
        [Produces("application/json")]
        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateSupplier([FromRoute] Guid id, IFormFile? image, IFormCollection formCollection)
        {
            var updateSupplier = await _supplier.GetSupplier(id);

            if (updateSupplier == null)
            {
                return NotFound();
            }

            var supplier = JsonConvert.DeserializeObject<Supplier>(formCollection["supplier"]);

            if (image?.Length > 0)
            {
                supplier.ImgPath = UploadFile.uploadImageFile(image);
            }
            else
            {
                supplier.ImgPath = updateSupplier.ImgPath;
            }

                supplier.Id = updateSupplier.Id;
                var  updatedSupplier = await _supplier.UpdateSupplier(supplier);
                return Ok(updatedSupplier);  
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult<Supplier>> DeleteSupplier(Guid id)
        {
            try
            {
                var supplierToDelete = await _supplier.GetSupplier(id);

                if (supplierToDelete == null)
                {
                    return NotFound($"Supplier with ID = {id} not found");
                }

                var deletedSupplier = await _supplier.DeleteSupplier(id);
                return Ok(deletedSupplier);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting Data");
            }
        }


       

    }
}

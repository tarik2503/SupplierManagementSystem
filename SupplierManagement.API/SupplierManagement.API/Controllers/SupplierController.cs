using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierManagement.API.IRepository;
using SupplierManagement.Data.Models;
using System.Net.Http.Headers;
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

        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] Supplier supplier)
        {
            try
            {
                if (supplier == null)
                {
                    return BadRequest();
                }
                supplier.Id = Guid.NewGuid();
                supplier.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var addSupplier = await _supplier.AddSupplier(supplier);

                return Ok(addSupplier);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while adding data to the database");
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateSupplier([FromRoute] Guid id, Supplier supplier)
        {
            var updateSupplier = await _supplier.GetSupplier(id);

            if (updateSupplier == null)
            {
                return NotFound();
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


        [HttpPost, DisableRequestSizeLimit]
        [Route("image")]
        public async Task<IActionResult> UploadEmployeeImage()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

    }
}

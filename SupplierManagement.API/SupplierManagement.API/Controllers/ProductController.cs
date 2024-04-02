using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;

        public ProductController(IProduct _product)
        {
            this._product = _product;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(await _product.GetProducts(userId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("supplier/{supplierId:Guid}")]
        public async Task<ActionResult> GetProductsBySupplierId([FromRoute] Guid supplierId)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(await _product.GetProductsBySupplierId(userId, supplierId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            try
            {
                var result = await _product.GetProduct(id);

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
        public async Task<IActionResult> AddProduct(IFormFile image, IFormCollection formCollection)
        {
            try
            {
                var product = JsonConvert.DeserializeObject<Product>(formCollection["product"]);
                if (product == null)
                {
                    return BadRequest();
                }
                var checkProduct = await _product.GetProductBySKU(product.ProductSKU);

                if (checkProduct != null)
                {
                    return NotFound(new
                    {
                        message = $"product with sku: {checkProduct.ProductSKU} already exist!"
                    });
                }

                if (image.Length > 0)
                {
                    product.ImagePath = UploadFile.uploadImageFile(image);
                    product.Id = Guid.NewGuid();
                    var addProduct = await _product.AddProduct(product);
                    return Ok(addProduct);
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
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, IFormFile? image, IFormCollection formCollection)
        {
            var updateProduct = await _product.GetProduct(id);
            if (updateProduct == null)
            {
                return NotFound();
            }

            var product = JsonConvert.DeserializeObject<Product>(formCollection["product"]);

            if (image?.Length > 0)
            {
                product.ImagePath = UploadFile.uploadImageFile(image);
            }
            else
            {
                product.ImagePath = updateProduct.ImagePath;
            }

            product.Id = updateProduct.Id;
            var updatedProduct = await _product.UpdateProduct(product);
            return Ok(updatedProduct); 

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult<Product>> DeleteProduct(Guid id)
        {
            try
            {
                var productToDelete = await _product.GetProduct(id);

                if (productToDelete == null)
                {
                    return NotFound($"Product with ID = {id} not found");
                }

                var deletedProduct = await _product.DeleteProduct(id);
                return Ok(deletedProduct);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting Data");
            }
        }
    }
}

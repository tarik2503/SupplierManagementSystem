using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                var checkProduct = await _product.GetProductBySKU(product.ProductSKU);

                if (checkProduct != null)
                {
                    return NotFound(new
                    {
                        Message = $"Product with SKU: {checkProduct.ProductSKU} already exist!"
                    });
                }
                product.Id = Guid.NewGuid();
                
                var addProduct = await _product.AddProduct(product);

                return Ok(addProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while adding data to the database");
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, Product product)
        {
            var updateProduct = await _product.GetProduct(id);

            if (updateProduct == null)
            {
                return NotFound();
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

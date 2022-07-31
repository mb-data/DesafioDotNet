using ApiDotNetCore.Entities;
using ApiDotNetCore.Repositories;
using ApiDotNetCore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private SqlServerRepository respository = new SqlServerRepository();


        [HttpGet("/api/v1/products")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var data = respository.GetAll();
                return Ok(new ResultViewModel<dynamic>(data));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<dynamic>("Internal server error"));
            }
        }

        [HttpGet("/api/v1/products/{productId}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int productId)
        {

            try
            {
                var data = respository.GetById(productId);
                if (data == null)
                    return NotFound(new ResultViewModel<dynamic>("Not Content Found"));

                return Ok(new ResultViewModel<dynamic>(data));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<dynamic>("Internal server error"));
            }
        }

        [HttpPost("/api/v1/products")]
        public async Task<IActionResult> PostAsync(
            [FromBody] ProductEntity product)
        {

            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<dynamic>(ModelState));

            try
            {
                var id = respository.Insert(product);
                product.Id = id;
                product.CreatedAt = DateTime.Now;

                return Ok(new ResultViewModel<dynamic>(product));
            }
            catch (Exception error)
            {
                return StatusCode(500, new ResultViewModel<dynamic>("Error to create product."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<dynamic>("Internal server erro"));
            }
        }

        [HttpPut("/api/v1/products/{productId}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int productId,
            [FromBody] ProductEntity product)
        {

            try
            {
                var data = respository.GetById(productId);
                if (data == null) return NotFound(new ResultViewModel<dynamic>("Not Content Found."));

                data.Name = product.Name;
                data.Brand = product.Brand;
                data.Price = product.Price;
                data.UpdatedAt = DateTime.Now;
                respository.Update(data, productId);
                return Ok(new ResultViewModel<dynamic>(data));
            }
            catch (Exception error)
            {
                return StatusCode(500, new ResultViewModel<dynamic>("Error to update product."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<dynamic>("Internal server error"));
            }


        }

        [HttpDelete("/api/v1/products/{productId}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int productId)
        {

            try
            {
                var data = respository.GetById(productId);
                if (data == null) return NotFound(new ResultViewModel<dynamic>("Not Content Found."));
                respository.Delete(productId);
                return Ok(new ResultViewModel<dynamic>(data));
            }
            catch (Exception error)
            {
                return StatusCode(500, new ResultViewModel<dynamic>("Error to update product."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<dynamic>("Internal server error"));
            }



        }
    }
}
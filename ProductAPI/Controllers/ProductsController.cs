using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllGetProducts();

            if (products is null)
                return NotFound("Not found Products in dataBase.");

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var products = await _productService.GetProductById(productId);

            if (products is null)
                return NotFound("Product not found in Database.");

            return Ok(products);
            
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var postResult = await _productService.AddProduct(product);

            if (postResult is null)
                return BadRequest("Product not entered in Database.");

            return Ok(postResult);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product request)
        {
            var product = await _productService.UpdateProduct(request);
            if (product is null)
                return BadRequest("Product not found in Database.");

            return Ok(product);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var delereResult = await _productService.DeleteProduct(productId);
            if (!delereResult)
                return BadRequest("Superhero not found in Database.");
         
            return Ok($"Product with productId: {productId}, delete from Database");

        }

    }
}

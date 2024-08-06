using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_projects.Domains;
using Product_projects.Interfaces;
using Product_projects.Repositories;

namespace Product_projects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository { get; set; }

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productRepository.ListProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
       public IActionResult Post( Product product)
        {
            try
            {
                
                _productRepository.Create(product);   
                return StatusCode(201);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productRepository.Delete(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Product product)
        {
            try
            {
                _productRepository.Update(id, product);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_productRepository.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

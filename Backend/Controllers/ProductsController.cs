using Backend.Filters;
using Backend.Models.Dtos;
using Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Constructor
        private readonly ProductRepository _repository;

        public ProductsController(ProductRepository repository)
        {
            _repository = repository;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var products = await _repository.GetAllAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest req)
        {

            if (ModelState.IsValid)
            {
                var product = await _repository.CreateAsync(req);
                if (product != null) 
                {

                    return Created("", product);
                }
            }
            return BadRequest();

        }



        [HttpGet("{id}")]

        public async Task<IActionResult> GetbyId(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product != null)
                return Ok(product);
            return NotFound();
           
        }






        [HttpGet("tag/{tag}")]
        
        public async Task<IActionResult> GetByTag(string tag)
        {

            var product = await _repository.GetByTagAsync(tag);
            if (product != null && product.Any())
                return Ok(product);
            return NotFound();

        }






        //[HttpDelete]
        //public async Task<IActionResult>Delete(Guid id)
        //{
        //    if (!ModelState.IsValid)
        //        BadRequest();

        //    await _repository.DeleteAsync(id);

        //}


















    }
}

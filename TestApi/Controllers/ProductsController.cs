using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProductsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                var Result = _context.Products.Include(p => p.Category).OrderBy(p => p.productName).ToList();

                return Ok(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var Result = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.productId == id);

                return Ok(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetEndProducts")]
        public IActionResult GetEndProducts()
        {
            return Ok(_context.Products
                .Where(X => X.duration >= DateTime.Now).ToList());
        }

        [HttpPost("PostProduct")]
        public IActionResult PostProduct( Product model)
        {
            try
            {
                if (model != null)
                {
                    _context.Products.Add(model);
                    _context.SaveChanges();
                    return Ok(model);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutProduct/{id}")]
        public IActionResult PutProduct(int id, Product model)
        {
            try
            {
                var Result = _context.Products.FirstOrDefault(c => c.productId == id);
                if (Result != null)
                {
                    Result.productName = model.productName;
                    Result.price = model.price;
                    Result.categoryId = model.categoryId;  
                    Result.creationDate = model.creationDate;
                    Result.startDate = model.startDate; 
                    Result.duration = model.duration;
                    _context.Products.Update(Result);
                    _context.SaveChanges();
                    return Ok(Result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
         
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var Result = _context.Products.FirstOrDefault(c => c.productId == id);
                if (Result != null)
                {
                    _context.Products.Remove(Result);
                    _context.SaveChanges();
                    return Ok(Result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

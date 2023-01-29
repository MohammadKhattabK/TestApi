using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Data;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public CategoriesController(ApplicationDBContext context)
        {
            _context = context;
        }
         
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var Result = _context.Categories.OrderBy(c => c.CategoryName).ToList();

                return Ok(Result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

       
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var Result = _context.Categories.OrderBy(c => c.CategoryName).FirstOrDefault(c => c.CategoryId == id);

                return Ok(Result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

      
        [HttpPost("PostCategory")]
        public IActionResult PostCategory( Category model)
        {
            try
            {
                _context.Categories.Add(model);
                _context.SaveChanges();
                return Ok(model);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("PutCategory/{id}")]
        public IActionResult PutCategory(int id, Category model)
        {
            try
            {
                var Result = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (Result != null)
                {
                    Result.CategoryName = model.CategoryName;
                    _context.Categories.Update(Result);
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
         
        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var Result = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (Result != null)
                {
                    _context.Categories.Remove(Result);
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

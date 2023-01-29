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
    public class CustomGroupsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public CustomGroupsController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var Result = _context.CustomGroups.ToList();

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
                var Result = _context.CustomGroups.FirstOrDefault(c => c.customGroupId == id);

                return Ok(Result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

       

        [HttpPost("PostCustomGroups")]
        public IActionResult PostCustomGroups(CustomGroup model)
        {
            try
            {
                _context.CustomGroups.Add(model);
                _context.SaveChanges();
                return Ok(model);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutCustomGroups/{id}")]
        public IActionResult PutCustomGroups(int id, CustomGroup model)
        {
            try
            {
                var Result = _context.CustomGroups.FirstOrDefault(c => c.customGroupId == id);
                if (Result != null)
                {
                    Result.customGroupTitle = model.customGroupTitle;
                    Result.productId = model.productId; 
                    _context.CustomGroups.Update(Result);
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

        
        [HttpDelete("DeleteCustomGroups/{id}")]
        public IActionResult DeleteCustomGroups(int id)
        {
            try
            {
                var Result = _context.CustomGroups.FirstOrDefault(c => c.customGroupId == id);
                if (Result != null)
                {
                    _context.CustomGroups.Remove(Result);
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

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
    public class CustomsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public CustomsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var Result = _context.Customs.ToList();

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
                var Result = _context.Customs.FirstOrDefault(c => c.customId == id);

                return Ok(Result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost("PostCustoms")]
        public IActionResult PostCustoms(Custom model)
        {
            try
            {
                _context.Customs.Add(model);
                _context.SaveChanges();
                return Ok(model);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut("PutCustoms/{id}")]
        public IActionResult PutCustoms(int id, Custom model)
        {
            try
            {
                var Result = _context.Customs.FirstOrDefault(c => c.customId == id);
                if (Result != null)
                {
                    Result.customValue = model.customValue;
                    Result.customKey = model.customKey;
                    Result.customGroupId= model.customGroupId;
                    _context.Customs.Update(Result);
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

        [HttpDelete("DeleteCustoms/{id}")]
        public IActionResult DeleteCustoms(int id)
        {
            try
            {
                var Result = _context.Customs.FirstOrDefault(c => c.customId == id);
                if (Result != null)
                {
                    _context.Customs.Remove(Result);
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

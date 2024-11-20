using BackendMCF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendMCF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StorageController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var locations = _context.MsStorageLocations.ToList();
            if (!locations.Any())
            {
                return NotFound(new { Message = "No storage locations found" });
            }

            return Ok(new { Message = "Data retrieved successfully", Data = locations });
        }


        [HttpGet]
        [Route("GetById/{locationId}")]
        public IActionResult GetById(string locationId)
        {
            var location = _context.MsStorageLocations.FirstOrDefault(l => l.LocationId == locationId);

            if (location == null)
            {
                return NotFound(new { Message = "Storage location not found" });
            }

            return Ok(new { Message = "Data retrieved successfully", Data = location });
        }
    }
}

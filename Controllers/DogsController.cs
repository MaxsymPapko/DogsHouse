using DogsHouseService.Data;
using DogsHouseService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace DogsHouseService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class DogsController : ControllerBase
    {
        private readonly DogsContext _context;
        public DogsController(DogsContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetDogs(string? attribute, string? order, int pageNumber =1, int pageSize =10)
        {
            var query = _context.Dogs.AsQueryable();

            // Сортування
            if (!string.IsNullOrEmpty(attribute))
            {
                bool descending = order?.ToLower() == "desc";
                query = attribute.ToLower() switch
                {
                    "name" => descending ? query.OrderByDescending(d => d.Name) : query.OrderBy(d => d.Name),
                    "color" => descending ? query.OrderByDescending(d => d.Color) : query.OrderBy(d => d.Color),
                    "taillength" => descending ? query.OrderByDescending(d => d.TailLength) : query.OrderBy(d => d.TailLength),
                    "weight" => descending ? query.OrderByDescending(d => d.Weight) : query.OrderBy(d => d.Weight),
                    _ => query
                };
            }

            
            var dogs = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(dogs);
        }
        [HttpPost]
        [Route("/dog")]
        public async Task<IActionResult> CreateDog([FromBody] Dog dog)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            if (await _context.Dogs.AnyAsync(d => d.Name == dog.Name))
                return Conflict("Dog with the same name already exists.");

            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();

            return Ok(dog);
        }
    }
}

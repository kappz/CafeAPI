using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CafeMenuAPI.Database;
using CafeMenuAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly CafeContext _context;

        public FoodController(CafeContext context)
        {
            _context = context;

            if (_context.Foods.Count() == 0)
            {
                _context.Foods.Add(new Food { FoodId = Guid.NewGuid(), Name = "Sandwich" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoods()
        {
            return await _context.Foods.ToListAsync();
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<Food>> GetFood(Guid guid)
        {
            var foodItem = await _context.Foods.FindAsync(guid);

            if (foodItem == null)
            {
                return NotFound();
            }

            return foodItem;
        }
    }
}
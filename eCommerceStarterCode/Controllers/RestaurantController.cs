using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandRestaurantSelector.Data;
using RandRestaurantSelector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandRestaurantSelector.Controllers
{
    [ApiController]
    [Route("api/restaurant")]
    
    public class RestaurantController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // <baseurl>/api/restaurant
        [HttpGet]
        public IActionResult Get()
        {
            var restaurant = _context.Restaurants;
            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Restaurant value)
        {
            _context.Restaurants.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }


    }
}

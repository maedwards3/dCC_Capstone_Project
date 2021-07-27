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
    [Route("api/rating")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RatingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // <baseurl>/api/rating
        [HttpGet]
        public IActionResult Get()
        {
            var ratings = _context.Ratings;
            return Ok(ratings);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Rating value)
        {
            _context.Ratings.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetRatingByUser(string userId)
        {
            var rating = _context.Ratings;
            var userRating = rating.Where(r => r.UserId == userId);
            return Ok(userRating);
        }


    }
}

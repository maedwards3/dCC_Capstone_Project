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

    [Route("api/savedFavorites")]
    [ApiController]
    public class SavedFavoritesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SavedFavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var savedFavorites = _context.SavedFavorites;
            return Ok(savedFavorites);
        }
        [HttpPost]
        public IActionResult Post([FromBody] SavedFavorite value)
        {
            _context.SavedFavorites.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        [HttpGet("userFavorite/{userId}")]
        public IActionResult GetSavedFavoritesByUser(string userId)
        {
            var savedFavorites = _context.Ratings;
            var userSavedFavorites = savedFavorites.Where(s => s.UserId == userId);
            return Ok(userSavedFavorites);
        }

        [HttpDelete("remove/{savedFavoriteId}")]
        public IActionResult DeleteSavedFavorite(int savedFavoriteId)
        {
            var savedFavorite = _context.SavedFavorites;
            var deleteFavorite = savedFavorite.Where(s => s.SavedFavoriteId == savedFavoriteId).SingleOrDefault();
            _context.SavedFavorites.Remove(deleteFavorite);
            _context.SaveChanges();
            return Ok("SavedFavorite Deleted");
        }


    }
}

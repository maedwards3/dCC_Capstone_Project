﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandRestaurantSelector.Data;
using RandRestaurantSelector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandRestaurantSelector.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        // <baseurl>/api/reviews
        [HttpGet]
        public IActionResult Get()
        {
            var reviews = _context.Reviews;
            return Ok(reviews);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Review value)
        {
            _context.Reviews.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }
    }
}

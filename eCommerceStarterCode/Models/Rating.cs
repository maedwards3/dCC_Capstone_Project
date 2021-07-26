using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RandRestaurantSelector.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int UserRating { get; set; }

        [ForeignKey ("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey ("Restaurant")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}

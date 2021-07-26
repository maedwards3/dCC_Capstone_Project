using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RandRestaurantSelector.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string UserReview { get; set; }

        [ForeignKey ("Restaurant")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [ForeignKey ("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}

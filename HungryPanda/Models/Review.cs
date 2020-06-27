using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryPanda.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int ResturantReviewId { get; set; } //foreign key
        public ResturantReview ResturantReview { get; set; }

        public DeliveryReview DeliveryReview { get; set; }
        public int DeliveryReviewId { get; set; }  //foreign key

    }
}
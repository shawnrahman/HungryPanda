using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryPanda.Models
{
    public class ResturantReview
    {
        public int Id { get; set; }
        public int TasteScore { get; set; }
        public int PriceScore { get; set; }
        public int OverallScore { get; set; }
        public string Comments { get; set; }

    }
}
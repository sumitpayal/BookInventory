using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMvc.Models
{
    public class Bookmvcmodel
    {
        public string Title { get; set; }
        [Required(ErrorMessage ="This field required")]
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
    }
}
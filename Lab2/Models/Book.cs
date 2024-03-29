﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Lab2.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please input Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please input Author")]
        [StringLength(50, ErrorMessage ="Author less than 50 characters")]
        public string Author { get; set; } 

        public int PublicYear { get; set; }
        public double Price { get; set; }

        public string Cover { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IGI_5.Models
{
    public class Furniture
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int Count { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}

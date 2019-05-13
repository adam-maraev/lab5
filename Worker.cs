using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IGI_5.Models
{
    public class Worker
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}

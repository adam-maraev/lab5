using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IGI_5.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public bool IsOrderComplete { get; set; }
        [Required]
        public int Discount { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public Furniture Furniture { get; set; }
        public Client Client { get; set; }
        public Worker Worker { get; set; }
    }
}

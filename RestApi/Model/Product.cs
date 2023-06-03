using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public double Calories { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public double Sugar { get; set; }
        public double Fiber { get; set; }
        public double Protein { get; set; }
        public double Salt { get; set; }
        public string ProductType { get; set; }


    }
}

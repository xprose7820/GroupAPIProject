using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupAPIProject.Data.Entities
{
    public class ProductEntity
    {
        [Key] 
        public int Id{get;set;}
        [Required]
        public string ProductName{get;set;}
        [Required]
        public string Description{get;set;}
        [Required]
        public string Category{get;set;}
        [Required]
        public double Price{get;set;} 
        
    }
}
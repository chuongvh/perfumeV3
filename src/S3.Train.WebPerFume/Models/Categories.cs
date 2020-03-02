using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S3.Train.WebPerFume.Models
{
    public class Categories
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Summary { get; set; }
        public Guid? ParentId { get; set; }
       
        public bool IsActive { get; set; }
        public IList<Products> Products { get; set; }

        public virtual Categories ParentCategory { get; set; }
        public virtual IList<Categories> ChildCategories { get; set; }
    }
}
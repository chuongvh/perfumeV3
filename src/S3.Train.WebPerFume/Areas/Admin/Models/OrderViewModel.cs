using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace S3.Train.WebPerFume.Areas.Admin.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        [ForeignKey("ShoppingCart")]

        [Display(Name="ShoppingCart")]
        [Required]
        public Guid ShoppingCart_Id { get; set; }
        [Required]
        public string DeliveryName { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public string DeliveryPhone { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime OrderDate { get; set; }
        
        [Display(Name = "Create Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
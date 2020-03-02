using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3.Train.WebPerFume.Areas.Admin.Models
{
    public class ProductAdvertisementViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Create Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Required]
        public string Title { get; set; }
        [UIHint("FormControlTextBox")]
        [Required]
        [AllowHtml]
        public string Description { get; set; }
        [Display(Name = "EventUrl")]
        [Required]
        public string EventUrl { get; set; }
        [Display(Name = "EventUrlCaption")]
        [Required]
        public string EventUrlCaption { get; set; }
        [Display(Name = "Image")]
        [Required]
        public string ImagePath { get; set; }
        
        public ProductAdvertisementType productadvertisementType { get; set; }
        public List<SelectListItem> DropDownProductAd { get; set; }

    }
}
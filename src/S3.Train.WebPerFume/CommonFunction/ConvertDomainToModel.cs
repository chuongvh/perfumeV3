using S3.Train.WebPerFume.Areas.Admin.Models;
using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S3.Train.WebPerFume.CommonFunction
{
    public static class ConvertDomainToModel
    {
        public static IList<ProductViewModel> GetProduct_SummaryInfo(IList<Product> products)
        {
            return products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
                CreateDate = x.CreatedDate,
                IsActive = x.IsActive
            }).ToList();
        }


    }
}
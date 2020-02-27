using System;
using System.Collections.Generic;
using S3Train.Domain;

namespace S3Train.Contract
{
    public interface IProductService : IGenenicServiceBase<Product>
    {
        IList<Product> GetProductsByBrandId(Guid brand_Id);
        IList<Product> GetProductsByVendorId(Guid vendor_Id);
    }
}

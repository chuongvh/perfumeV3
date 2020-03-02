using S3Train.Contract;
using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Service
{
    public class ProductAdvertisementService : GenenicServiceBase<ProductAdvertisement>, IProductAdvertisement
    {
        public ProductAdvertisementService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public ProductAdvertisement GetWomenSquareBanner()
        {
            return this.EntityDbSet.FirstOrDefault(b => b.AdType == ProductAdvertisementType.WomenSquareBanner && b.IsActive);
        }
        public ProductAdvertisement GetMenSquareBanner()
        {
            return this.EntityDbSet.FirstOrDefault(b => b.AdType == ProductAdvertisementType.MenSquareBanner && b.IsActive);
        }
        public ProductAdvertisement GetUnisexSquareBanner()
        {
            return this.EntityDbSet.FirstOrDefault(b => b.AdType == ProductAdvertisementType.UnisexSquareBanner && b.IsActive);
        }

    }
}

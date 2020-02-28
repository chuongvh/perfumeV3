using S3.Train.WebPerFume.Areas.Admin.Models;
using S3.Train.WebPerFume.CommonFunction;
using S3Train.Contract;
using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3.Train.WebPerFume.Areas.Admin.Controllers
{
    public class ProVarationController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductVariationService _productVariationService;
        private readonly IProductImageService _productImageService;

        public ProVarationController()
        {

        }

        public ProVarationController(IProductService productService, IProductVariationService productVariationService, 
            IProductImageService productImageService)
        {
            _productService = productService;
            _productVariationService = productVariationService;
            _productImageService = productImageService;
        }

        // GET: Admin/ProVaration
        public ActionResult Index()
        {
            var model = GetProducts(_productService.SelectAll().OrderBy(p=>p.Name).ToList());
            return View(model);
        }

        [HttpGet]
        public ActionResult AddOrEditProductVariation(Guid? id)
        {
            ProVarationViewModel model = new ProVarationViewModel();

            model.DropDownProduct = DropDownListDomain.DropDownList_Product(_productService.SelectAll());
            model.DropDownVolume = DropDownListDomain.DropDownList_Volume();

            if (id.HasValue)
            {
                var productVariation = _productVariationService.GetById(id.Value);

                model = ConvertDomainToModel.ConvertModelFromDomainToProVa(productVariation);

                model.Image = _productImageService.GetProductImage(model.Id) == null ? null :
                                        ConvertDomainToModel.GetProductImage(_productImageService.GetProductImage(model.Id));

                return View(model);
            }
            else
                return View(model);
        }

        /// <summary>
        /// If id != null Update else Create new
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="model">ProductViewModel</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddOrEditProductVariation(Guid? id, ProVarationViewModel model, HttpPostedFileBase image)
        {
            try
            {
                bool isNew = !id.HasValue;
                string localFile = Server.MapPath("~/Content/img/product-men");

                // isNew = true update UpdatedDate of product
                // isNew = false get it by id
                var productVariation = isNew ? new ProductVariation
                {
                    UpdatedDate = DateTime.Now
                } : _productVariationService.GetById(id.Value);

                productVariation.Product_Id = model.Product_Id;
                productVariation.SKU = model.SKU;
                productVariation.Volume = model.Volume;
                productVariation.Price = model.Price;
                productVariation.StockQuantity = model.StockQuantity;
                productVariation.IsActive = true;

                // if model.DiscountPrice != null then DiscountPrice =  model.DiscountPrice  else equal 0
                productVariation.DiscountPrice = (model.DiscountPrice.ToString() != null) ? model.DiscountPrice : 0;

                if (isNew)
                {
                    productVariation.CreatedDate = DateTime.Now;
                    productVariation.Id = Guid.NewGuid();
                    _productVariationService.Insert(productVariation);
                }
                else
                {
                    _productVariationService.Update(productVariation);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// get product variation have image with image id
        /// </summary>
        /// <param name="proVas">ProductVatiation List</param>
        /// <returns>ProVarationViewModel List</returns>
        public IList<ProVarationViewModel> GetProductVariations(IList<ProductVariation> proVas)
        {
            return proVas.Select(x => new ProVarationViewModel
            {
                Id = x.Id,
                SKU = x.SKU,
                StockQuantity = x.StockQuantity,
                Price = x.Price,
                Volume = x.Volume,
                Image = _productImageService.GetProductImage(x.Id) == null ? null : 
                                        ConvertDomainToModel.GetProductImage(_productImageService.GetProductImage(x.Id)),
                DiscountPrice =x.DiscountPrice,
                CreateDate = x.CreatedDate,
                UpdateDate = x.UpdatedDate,
                IsActive = x.IsActive
            }).ToList();
        }


        /// <summary>
        /// Get product have product variation inside
        /// </summary>
        /// <param name="products">Product List</param>
        /// <returns>ProductModel List</returns>
        public IList<ProductModel> GetProducts(IList<Product> products)
        {
            return products.Select(x => new ProductModel
            {
                Id = x.Id,
                ProductName = x.Name,
                ProductImage = x.ImagePath,
                proVarationViewModels = GetProductVariations(
                    _productVariationService.GetProductVariations(x.Id)).ToList(),
            }).ToList();
        }

    }
}
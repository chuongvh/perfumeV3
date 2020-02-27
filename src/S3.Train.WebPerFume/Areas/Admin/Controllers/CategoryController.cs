//using S3.Train.WebPerFume.Areas.Admin.Models;
//using S3.Train.WebPerFume.CommonFunction;
//using S3Train.Contract;
//using S3Train.Domain;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace S3.Train.WebPerFume.Areas.Admin.Controllers
//{
//    public class CategoryController : Controller
//    {
//        private readonly IProductService _productService;
//        private readonly ICategoryService _categoryService;

//        public CategoryController()
//        {

//        }

//        public CategoryController(IProductService productService, ICategoryService categoryService)
//        {
//            _productService = productService;
//            _categoryService = categoryService;
//        }

//        // GET: Admin/Category
//        public ActionResult Index()
//        {
//            var model = GetCategorys(_categoryService.SelectAll());
//            return View(model);
//        }


//        /// <summary>
//        /// Detail Category
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns>Detail View</returns>
//        public ActionResult DetailCategory(Guid id)
//        {
//            var category = _categoryService.GetById(id);
//            var model = new CategoryViewModel
//            {
//                Id = category.Id,
//                Name = category.Name,
               
//                CreateDate = category.CreatedDate,
//                IsActive = category.IsActive,
//                Summary = category.Summary,
              
//                UpdateDate = category.UpdatedDate,
//            };
//            return View(model);
//        }

//        [HttpGet]
//        public ActionResult AddOrEditCategory(Guid? id)
//        {
//            CategoryViewModel model = new CategoryViewModel();

//            if (id.HasValue)
//            {
//                var category = _categoryService.GetById(id.Value);
//                model.Id = category.Id;
//                model.Name = category.Name;
              
//                model.Summary = category.Summary;
//                model.UpdateDate = category.UpdatedDate;
//                model.CreateDate = category.CreatedDate;
//                model.IsActive = category.IsActive;
//                return View(model);
//            }
//            else
//                return View(model);
//        }

//        /// <summary>
//        /// If id != null Update else Create new
//        /// </summary>
//        /// <param name="id">Guid</param>
//        /// <param name="model">ProductViewModel</param>
//        /// <returns></returns>
//        [HttpPost]
//        [ValidateInput(false)]
//        public ActionResult AddOrEditatCategory(Guid? id, CategoryViewModel model, HttpPostedFileBase logo)
//        {
//            try
//            {
//                bool isNew = !id.HasValue;
              

//                // isNew = true update UpdatedDate of product
//                // isNew = false get it by id
//                var category = isNew ? new Category
//                {
//                    UpdatedDate = DateTime.Now
//                } : _categoryService.GetById(id.Value);

//                category.Name = model.Name;
//                category.Summary = model.Summary;
               
//                category.IsActive = true;

//                if (isNew)
//                {
//                    category.CreatedDate = DateTime.Now;
//                    category.Id = Guid.NewGuid();
//                    _categoryService.Insert(category);
//                }
//                else
//                {
//                    _categoryService.Update(category);
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return RedirectToAction("Index");
//        }



//        [HttpGet]
//        public PartialViewResult DeleteCategory(Guid id)
//        {
//            var category = _categoryService.GetById(id);
//            var model = new ProductViewModel
//            {
//                Name = $"{category.Name}"
//            };
//            return PartialView("~/Areas/Admin/Views/category/_DeleteCategoryPartial.cshtml", model);
//        }

//        [HttpPost]
//        public ActionResult DeleteCategory(CategoryViewModel model)
//        {
//            var category = _categoryService.GetById(model.Id);
//            _categoryService.Delete(category);
//            return RedirectToAction("Index");
//        }

//        private IList<CategoryViewModel> GetCategorys(IList<Category> categories)
//        {
//            return categories.Select(x => new CategoryViewModel
//            {
//                Id = x.Id,
//                Name = x.Name,
//                Summary = x.Summary,
               
//                CreateDate = x.CreatedDate,
//                UpdateDate = x.UpdatedDate,
               
//                IsActive = x.IsActive
//            }).ToList();
//        }
//    }
//}
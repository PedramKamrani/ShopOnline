using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CorService.ExtinsionMethod;
using CorService.Security;
using CorService.Services;
using CorService.Services.Category;
using CorService.Services.Gallery;
using CorService.Services.IService;
using CorService.Services.RatingService;
using CorService.ViewModels.Brand;
using CorService.ViewModels.Categorey;
using CorService.ViewModels.Product;
using DataLayer.Entites.Brand;
using DataLayer.Entites.CategoryData;
using DataLayer.Entites.Product;
using DataLayer.Entites.Proprty;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StorPedramBackend.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AutoValidateAntiforgeryToken]
    public class CatalogController : Controller
    {

        private ICategoryService _CategoryService;
        private IProductService _ProductService;
        private IBrandService _BrandtService;
        private IProprtyService _ProprtyService;
        private IGalleryServeice _GalleryServeice;
        private IRatingService _ratingyServeice;
        public CatalogController(ICategoryService CategoryService, IProductService ProductService
            , IBrandService BrandtService, IProprtyService ProprtyService, IGalleryServeice GalleryServeice
            , IRatingService ratingyServeice)
        {
            _CategoryService = CategoryService;
            _ProductService = ProductService;
            _BrandtService = BrandtService;
            _ProprtyService = ProprtyService;
            _GalleryServeice = GalleryServeice;
            _ratingyServeice = ratingyServeice;
        }
        #region Category
        public IActionResult CategoryList()
        {
            return View(_CategoryService.GetCategoresForAdmin());
        }
        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            Categores categori = _CategoryService.GetFindById(id);
            if (categori == null)
            {
                TempData["res"] = "faild";
                return RedirectToAction("CategoryList");
            }
            categori.IsDelete = true;
            bool res = _CategoryService.DeleteCategory(categori);
            TempData["res"] = res ? "success" : "faild";
            return RedirectToAction("CategoryList");
        }
        public IActionResult CreateCategory()
        {
            ViewBag.CategoryList = _CategoryService.GetCategoryForAdd();
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            string imgeName = "";
            if (viewModel.Image != null)
            {
                if (ImgeSecurity.ImageValitor(viewModel.Image))
                {
                    imgeName = viewModel.Image.SaveImage("", "wwwroot/img/category");
                }
                else
                {
                    ModelState.AddModelError("Image", "لطفا یک فایل عکس قرار بدید");
                }
            }
            Categores categores = new Categores
            {
                FaTitle = viewModel.FaTitle,
                EnTitle = viewModel.EnTitle,
                Descrption = viewModel.Descrption,
                ImgName = imgeName

            };
            bool res = _CategoryService.AddCategory(categores, viewModel.ParentList);
            TempData["res"] = res ? "success" : "faild";
            return RedirectToAction("CategoryList");
        }
        public IActionResult EditCategory(int id)
        {
            Categores categores = _CategoryService.GetFindById(id);
            if (categores == null)
            {
                TempData["res"] = "faild";
                return RedirectToAction("CategoryList");
            }
            EditCategoryViewModel edit = new EditCategoryViewModel()
            {
                Id = categores.CategoryId,
                Descrption = categores.Descrption,
                CurrentImage = categores.ImgName,
                EnTitle = categores.EnTitle,
                FaTitle = categores.FaTitle,

            };
            ViewBag.CategoryList = _CategoryService.GetCategoryForAdd();
            ViewBag.ParentList = _CategoryService.GetSubCategory(id);
            return View(edit);
        }
        [HttpPost]
        public IActionResult EditCategory(EditCategoryViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }
            string filname = TempData["Imgname"] != null ? TempData["Imgname"].ToString() : "";
            if (edit.Image != null)
            {
                if (ImgeSecurity.ImageValitor(edit.Image))
                {
                    filname.DeleteImage("wwwroot/img/category/");

                    edit.Image.SaveImage(filname, "wwwroot/img/category/");

                }
                else
                {
                    ModelState.AddModelError("DesktopImg", "لطفا یک فایل عکس قرار بدید");
                }
            }
            Categores cat = new Categores
            {
                CategoryId = int.Parse(TempData["Id"].ToString()),
                Descrption = edit.Descrption,
                EnTitle = edit.EnTitle,
                FaTitle = edit.FaTitle,
            };
            bool res = _CategoryService.AddCategory(cat, edit.ParentList);
            TempData["res"] = res ? "success" : "faild";
            return RedirectToAction("CategoryList");

        }
        #endregion

        #region Product
        public IActionResult ProductListContainer()
        {
            var Content = _ProductService.GetProductsForAdmin("", 1, 2);
            ViewBag.pagecount = Content.Item1;
            ViewBag.pagenumber = 1;
            ViewBag.searchtext = "";

            return View(Content.Item2);
        }
        public IActionResult ProductList(string searchtext = "", int pagenumber = 1)
        {
            var content = _ProductService.GetProductsForAdmin(searchtext, pagenumber, 2);
            ViewBag.pagecount = content.Item1;
            ViewBag.pagenumber = pagenumber;
            ViewBag.searchtext = searchtext;
            return View(content.Item2);
        }
        public IActionResult CreateProduct()
        {
            ViewBag.CategoryList = _CategoryService.GetCategoryForAdd();
            ViewBag.BrandList = _BrandtService.GetBrandForAddProduct();
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(AddProductViewModel add)
        {
            ViewBag.CategoryList = _CategoryService.GetCategoryForAdd();
            ViewBag.BrandList = _BrandtService.GetBrandForAddProduct();
            string imgname = "";
            if (add.ImgName != null)
            {
                if (ImgeSecurity.ImageValitor(add.ImgName))
                {
                    imgname = add.ImgName.SaveImage("", "wwwroot/img/Product");
                }
                else
                {
                    ModelState.AddModelError("ImgName", "یک فایل درست انتخاب کنید");
                    return View(add);
                }
            }
            if (ModelState.IsValid)
            {
                Products p = new Products
                {
                    FaTitle = add.FaTitle,
                    EnTitle = add.EnTitle,
                    IsPublish = add.IsPublished,
                    ImgName = imgname,
                    CategoryID = add.CategoryID,
                    BrandID = add.BrandID,
                    CreteDate = DateTime.Now,
                    UpdateDate = DateTime.Now,

                };
                int productid = _ProductService.AddProduct(p);
                List<int> ParentList = _CategoryService.GetParentCategory(p.CategoryID);
                List<ProductCategory> productCategories = new List<ProductCategory>();
                foreach (var item in ParentList)
                {
                    productCategories.Add(new ProductCategory
                    {
                        Categoryid = item,
                        ProuctId = productid,

                    });

                }
                bool res = _CategoryService.AddProductCategory(productCategories);
                TempData["res"] = res ? "sucsse" : "faild";
                return RedirectToAction("ProductList");
            }
            return View(add);
        }
        #endregion
        #region Proprty
        #region Group
        public IActionResult ProprtyGroupList(int pagenumber = 1)
        {
            ViewBag.pagecount = _ProprtyService.GetProprtyGroupCount();
            ViewBag.pagenumber = pagenumber;
            return View(_ProprtyService.GetProprtyGroups(pagenumber));
        }
        public IActionResult CreatePropertyGroup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePropertyGroup(ProprtyGroup group)
        {
            if (!ModelState.IsValid)
            {
                return View(group);
            }
            bool res = _ProprtyService.AddGroupProprty(group);
            TempData["res"] = res ? "succse" : "faild";
            return RedirectToAction("ProprtyGroupList");
        }
        public IActionResult EditGruop(int id)
        {
            ViewBag.Gruop = _ProprtyService.GetProprtyGroupsForEdit();
            return View(_ProprtyService.FindProprtyGroup(id));
        }
        [HttpPost]
        public IActionResult EditGruop(ProprtyGroup group)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Gruop = _ProprtyService.GetProprtyGroupsForEdit();
                return View();
            }
            bool res = _ProprtyService.EditeGroupProprty(group);
            TempData["res"] = res ? "succse" : "faild";
            return RedirectToAction("ProprtyGroupList");

        }
        [HttpPost]
        public IActionResult DeleteGroup(int id)
        {
            var group = _ProprtyService.FindProprtyGroup(id);
            if (group == null)
            {
                TempData["res"] = "faild";
                return RedirectToAction("ProprtyGroupList");
            }
            group.IsDelete = true;
            bool res = _ProprtyService.DeleteProprtyGruop(group);
            TempData["res"] = res ? "succse" : "faild";
            return RedirectToAction("ProprtyGroupList");
        }
        #endregion

        #region Name
        public IActionResult PropertyNameList()
        {
            return View(_ProprtyService.GetProprtyNamesForAdmin());
        }
        public IActionResult CreatePropertyName()
        {
            ViewBag.Groups = _ProprtyService.GetProprtyGroupsForAdmin();
            ViewBag.CategoryList = _CategoryService.GetCategoryForAdd();

            return View();
        }
        [HttpPost]
        public IActionResult CreatePropertyName(ProprtyName names, List<int> category)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Groups = _ProprtyService.GetProprtyGroupsForAdmin();
                ViewBag.Category = _CategoryService.GetCategoryForAdd();
                return View(names);
            }
            int id = _ProprtyService.AddPropertyName(names);
            if (id > 0)
            {
                List<PropertyCategory> propertyCategory = new List<PropertyCategory>();
                foreach (var item in category)
                {
                    propertyCategory.Add(new PropertyCategory
                    {
                        PropertyNameId = id,
                        CategoryId = item
                    });
                }

                bool res = _ProprtyService.AddNameCategory(propertyCategory);
                TempData["res"] = res ? "success" : "faild";
                return RedirectToAction(nameof(PropertyNameList));
            }
            TempData["res"] = "faild";
            return RedirectToAction(nameof(PropertyNameList));
        }
        public IActionResult EditPropertyName(int id)
        {
            var name = _ProprtyService.FindProprtyNameByAdmin(id);
            if (name == null)
            {
                TempData["res"] = "faild";
                return RedirectToAction(nameof(PropertyNameList));
            }
            ViewBag.Groups = _ProprtyService.GetProprtyGroupsForAdmin();
            return View(name);
        }
        [HttpPost]
        public IActionResult EditPropertyName(ProprtyName name)
        {
            name.PropertyNameId = int.Parse(TempData["id"].ToString());
            if (ModelState.IsValid)
            {
                bool res = _ProprtyService.EditProprtyName(name);
                TempData["res"] = res ? "succsse" : "Faild";
                return RedirectToAction("PropertyNameList");
            }
            ViewBag.Groups = _ProprtyService.GetProprtyGroupsForAdmin();
            return View(name);
        }
        #endregion

        #region Value
        public IActionResult PropertyValueList()
        {
            return View(_ProprtyService.GetPropertyValuesForAdmin());
        }
        public IActionResult CreatePropertyValue()
        {
            ViewBag.names = _ProprtyService.GetProprtyNamesForAdmin();
            return View();
        }
        [HttpPost]
        public IActionResult CreatePropertyValue(PropertyValue values)
        {
            if (ModelState.IsValid)
            {
                bool res = _ProprtyService.AddProprtyValue(values);
                TempData["res"] = res ? "sucsse" : "faild";
                return RedirectToAction("PropertyNameList");

            }
            ViewBag.names = _ProprtyService.GetProprtyNamesForAdmin();
            return View(values);
        }
        public IActionResult EditValue(int id)
        {
            var name = _ProprtyService.FindProprtyValueByAdmin(id);
            ViewBag.names = _ProprtyService.GetProprtyNamesForAdmin();
            return View(name);
        }
        [HttpPost]
        public IActionResult EditValue(PropertyValue values)
        {
            values.PropertyValueId = int.Parse(TempData["id"].ToString());
            if (!ModelState.IsValid)
            {
                ViewBag.names = _ProprtyService.GetProprtyNamesForAdmin();
                return View(values);
            }
            bool res = _ProprtyService.EditValue(values);
            TempData["res"] = res ? "sucsse" : "faild";
            return RedirectToAction("PropertyValueList");

        }
        [HttpPost]
        public IActionResult DeleteProprtyValue(int id)
        {
            var proprtyvalue = _ProprtyService.FindProprtyValueByAdmin(id);
            if (proprtyvalue == null)
            {
                TempData["res"] = "faild";
                return RedirectToAction("PropertyValueList");
            }
            proprtyvalue.ISDelete = true;
            bool res = _ProprtyService.DeleteProprtyValue(proprtyvalue);
            TempData["res"] = res ? "success" : "faild";
            return RedirectToAction("PropertyValueList");
        }
        #endregion
        #endregion

        #region Gallry
        public IActionResult GalleryList(int id)
        {
            ViewBag.productid = id;
            return View(_GalleryServeice.GetProductImagesForAdmin(id));
        }
        public IActionResult CreateProductImage(IFormFile imagname)
        {
            int id = int.Parse(TempData["ProductImageid"].ToString());
            string iname = "";
            if (imagname != null)
            {
                if (ImgeSecurity.ImageValitor(imagname))
                {
                    iname = imagname.SaveImage("", "wwwroot/img/product/gallery");
                    string oldpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product/gallery", iname);
                    string newpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product/gallery/tumb", iname);
                    oldpath.Image_resize(newpath, 150, 150);
                    ProductImage productImage = new ProductImage
                    {
                        ImgName = iname,
                        ProductId = id
                    };
                    _GalleryServeice.AddProductImage(productImage);
                }
                else
                {

                    return RedirectToAction("GalleryList", new { id = id });
                }

            }


            return RedirectToAction("GalleryList", new { id = id });
        }
        [HttpPost]
        public IActionResult DeleteProductImge(int id)
        {

            ProductImage image = _GalleryServeice.FindImageForAdmin(id);
            bool res = _GalleryServeice.DeleteProductImage(image);
            TempData["res"] = res ? "succse" : "faild";
            return RedirectToAction("GalleryList", new { ido = id });
        }
        #endregion
        #region Brand
        public IActionResult BrandList(int pagenumber= 1)
        {
            ViewBag.cunt = _BrandtService.Brandcunt();
            ViewBag.page = pagenumber;
            return View(_BrandtService.BrandForAdmin(pagenumber));
        }

        public IActionResult DeleteBrand(int id)
        {
            var brandid = _BrandtService.FindBrandById(id);
            if (brandid != null)
            {
                brandid.IsDelete = true;
                _BrandtService.DeleteBrand(brandid);
                return RedirectToAction("BrandList");
            }
            return RedirectToAction("BrandList");
        }
        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateBrand(BrandAddViewModel brand)
        {
            string imagname = "";
            if (brand.Image != null)
            {
                if (ImgeSecurity.ImageValitor(brand.Image))
                {
                    imagname = brand.Image.SaveImage("", "wwwroot/img/brand");

                }
                else
                {
                    ModelState.AddModelError("ImgName", "یک فایل درست انتخاب کنید");
                    return View(brand);
                }

                Brand br = new Brand
                {
                    FaTitle = brand.FaTitle,
                    EnTitle = brand.EnTitle,
                    ImgName = imagname,
                    Descrption = brand.Deccription,
                    IsDelete = false,
                };
                bool res = _BrandtService.AddBrand(br);
                TempData["res"] = res ? "sucsse" : "faild";
                return RedirectToAction("BrandList");

            }

            return View(brand);
        }
        public IActionResult EditBrand(int id)
        {
            Brand brand = _BrandtService.FindBrandById(id);
            if (brand == null)
            {
                TempData["res"] = "faild";
                return RedirectToAction("CategoryList");
            }
            BrandEditViewModel model = new BrandEditViewModel
            {
                Deccription=brand.Descrption,
                EnTitle=brand.EnTitle,
                FaTitle=brand.FaTitle,
                IsDelete=brand.IsDelete,
                id=brand.BrandId,
               ImageName= brand.ImgName

            };
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult EditBrand(BrandEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //int ide =int.Parse(ViewData["id"].ToString());
            string filname = TempData["Imgname"] != null ? TempData["Imgname"].ToString() : "";
            if (model.Image != null)
            {
                if (ImgeSecurity.ImageValitor(model.Image))
                {
                    filname.DeleteImage("wwwroot/img/brand/");

                    model.Image.SaveImage(filname, "wwwroot/img/brand/");

                }
                else
                {
                    ModelState.AddModelError("DesktopImg", "لطفا یک فایل عکس قرار بدید");
                }
            }
            Brand brand = new Brand
            {
                BrandId=model.id,
                Descrption = model.Deccription,
                EnTitle = model.EnTitle,
                FaTitle = model.FaTitle,
                IsDelete = model.IsDelete,
                ImgName=filname

            };
            bool res=_BrandtService.EditBrand(brand);
            TempData["res"] = res ? "sucsee" : "faild";
            return RedirectToAction("BrandList");

        }
        #endregion
        #region Rating
        public IActionResult RatingAttributeList()
        {
            return View(_ratingyServeice.ShowAttibuitForAdmin());
        }
        public IActionResult CreateAttribute()
        {
            ViewBag.CategoryList = _CategoryService.GetCategoryForAdd();
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateAttribute(RatingAttributs rating)
        {
          bool res= _ratingyServeice.AddRating(rating);
            TempData["res"] = res ? "sucsse" : "faild";
            return RedirectToAction("RatingAttributeList");
        }
            #endregion
        }
}
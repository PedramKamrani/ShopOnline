using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorService.Services.IService;
using CorService.Services.Sller;
using CorService.ViewModels.Product;
using DataLayer.Entites.Product.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StorPedramBackend.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICommentService _CommentService;
        private IFAQService _FAQService;
        private IUserService _Userservice;
        private IVarintService _VarintService;

        public ProductController(IProductService productService, ICommentService CommentService
            , IFAQService FAQService, IUserService Userservice, IVarintService VarintService
            )
        {
            _productService = productService;
            _CommentService = CommentService;
            _FAQService = FAQService;
            _Userservice = Userservice;
            _VarintService = VarintService;
        }
       
        public IActionResult ProductDetail(int id)
        {
            var product = _productService.GetProductDetailUser(id);
            if (product== null)
            {
                return NotFound();
            }
          
            return View(product);
        }

    
       [HttpPost]
        public IActionResult CommentTab(int ProductId, int sort,string fatitle)
        {
            ViewBag.faTitle = fatitle;
            Tuple<List<CommentForUserViewModel>, List<ReviewRatingViewModel>, int> comment = _CommentService.GetCommentForUser(ProductId,2);
            ViewBag.pagecount = comment.Item3;
            ViewBag.commentcount = 2;
            ViewBag.Commentsort = sort;
            ViewBag.pagenumber = 1;
            ViewBag.productid = ProductId;
            
            return View(comment);
        }
        public IActionResult CommentList(int ProductId, int pagenumber,int sort,int commentcount)
        {
            ViewBag.pagenumber = pagenumber;
            ViewBag.productid = ProductId;
            
            ViewBag.Commentsort = 2;
            return View(_CommentService.GetCommentByFilter(ProductId, pagenumber, sort, 2));
        }
        public IActionResult FAQ(int productid,int pagenumber,int sort,int faqcount)
        {
            ViewBag.faqcount =(faqcount== 0) ? _FAQService.FAQCount(productid) : faqcount;
            ViewBag.faqtsort = sort;
            ViewBag.faqPageNumber = pagenumber;


            return View(_FAQService.GetFAQ(productid, pagenumber, sort, 3));

        }
        
        public IActionResult AddComm(int id)
        {
            return View(_productService.FindProductId(id));
        }
    }
}
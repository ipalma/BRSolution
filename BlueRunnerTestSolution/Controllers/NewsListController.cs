
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using PagedList;
using Models.Models;
using Services.Services;

namespace BlueRunnerTestSolution.Controllers
{
    public class NewsListController : Controller
    {
        private readonly IServices<Article> _articleService;
        private int pageSize = 6;

        public NewsListController(IServices<Article> articleService)
        {
            _articleService = articleService;
        }
        public NewsListController() { }
        // GET: NewsList
        public ActionResult Index(string searchStr, int? page)
        {
               
            ViewBag.Title = "Title";
            ViewBag.Section = "Section";
            ViewBag.TrailText = "Trail-Text";
            ViewBag.CurrentSearch = searchStr;

            List<Article> data = new List<Article>();

            //string searchStr = string.Empty;

            data = _articleService.GetList(searchStr);
            
            int pageNumber = page ?? 1;

            return View(data.ToPagedList(pageNumber, this.pageSize));
        }
    }
}
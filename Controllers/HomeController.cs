using Microsoft.AspNetCore.Mvc;
using SearchProductCode.Data;
using SearchProductCode.Models;
using System.Diagnostics;
using X.PagedList;

namespace SearchProductCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _db;
        [BindProperty]
        public LogoRecip LogoRecM { get; set; }

        public HomeController(DatabaseContext db)
        {
            _db = db;
            LogoRecM = new LogoRecip();
        }

        public IActionResult Index(string? term)
        {
            return View();
        }
        public IActionResult Search(string? term)
        {
            List<LogoRecip> Result = _db.LogoRecips.Where(m => m.LineProduct == term && m.LINETYPE == "4").ToList();

            List<LogoRecip> UstRecips = _db.LogoRecips.Where(m => m.LineProduct == term && m.LINETYPE == "0").ToList();

            ViewBag.Term = term;

            ViewBag.Result = Result;
            ViewBag.UstRecips = UstRecips;

            return View(_db.LogoRecips.ToList());
          
        }
        public IActionResult DetailedSearch(string? productType,string? sap,string? origin,string? finish )
        {

            List<LogoRecip> results = _db.LogoRecips.Where(x=>x.LINETYPE=="4" && x.LineProduct.Length>=17).ToList();

            results = productType != null ? results.Where(m => m.LineProduct.Substring(0, 2).Contains(productType)).ToList() : results;
            results = sap != null ? results.Where(m => m.LineProduct.Substring(5, 6).Contains(sap)).ToList() : results;
            results = origin != null ? results.Where(m => m.LineProduct.Substring(11,2).Contains(origin)).ToList() : results;
            results=finish != string.Empty && finish != null ? results.Where(m => m.LineProduct.Substring(13, 1).Contains(finish)).ToList() : results;

            List<LogoRecip> ustresults = _db.LogoRecips.Where(x => x.LINETYPE == "0" && x.LineProduct.Length >= 17).ToList();

            ustresults = productType != string.Empty && productType != null ? ustresults.Where(m => m.LineProduct.Substring(0, 2).Contains(productType)).ToList() : ustresults;
            ustresults = sap != string.Empty && sap != null ? ustresults.Where(m => m.LineProduct.Substring(5, 6).Contains(sap)).ToList() : ustresults;
            ustresults = origin != string.Empty && origin != null ? ustresults.Where(m => m.LineProduct.Substring(11, 2).Contains(origin)).ToList() : ustresults;
            ustresults = finish != string.Empty && finish != null ? ustresults.Where(m => m.LineProduct.Substring(13, 1)==finish).ToList(): ustresults;


            ViewBag.Result = results;
            ViewBag.UstRecips = ustresults;

            ViewBag.Term1 = productType;
            ViewBag.Term2 = sap;
            ViewBag.Term3 = origin;
            ViewBag.Term4 = finish;

            return View(_db.LogoRecips.ToList());

        }







    }
}
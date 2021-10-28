using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concreate;


namespace Mvc_Kamp.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        
        public ActionResult Index()
        {
            Context context = new Context();

            //Toplam kategori sayısı
            var CategoryCount = context.Categories.Count();
            ViewBag.categorycount = CategoryCount;

            //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var yazid = context.Categories.Where(x => x.CategoryName == "Yazılım").FirstOrDefault();
            var SoftwareCount = context.headings.Count(x => x.CategoryID == yazid.CategoryID);
            ViewBag.softwarecount = SoftwareCount;

            //Yazar adında 'a' harfi geçen yazar sayısı
            var WriterFind = context.writers.Count(x=>x.WriterName.Contains("a"));
            ViewBag.writerfind = WriterFind;

            //En fazla başlığa sahip kategori adı ve sayısı

            var CategoryValue = context.headings.GroupBy(y => y.CategoryID).OrderByDescending(y => y.Count()).Select(y => new { id = y.Key, amount = y.Count() }).FirstOrDefault();
            var CategoryName = context.Categories.Where(x => x.CategoryID == CategoryValue.id).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.categoryname = CategoryName;
            ViewBag.categoryamount = CategoryValue.amount;

            // Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var CategoryDifference = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.categorydifference = CategoryDifference;

            return View();

        }
    }
}
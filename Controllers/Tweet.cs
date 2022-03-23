using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Tweet : Controller
    {
        private readonly ApplicationDbContext _db;

        public Tweet(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public JsonResult AsCreateTwit(DaTwit twit)
        {
            _db.DaTwits.Add(twit);
            _db.SaveChanges();
            return Json(twit);
        }
    }
}

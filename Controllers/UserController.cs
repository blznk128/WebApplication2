using WebApplication2.Models;
using WebApplication2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;


namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        //List<User> user = new List<User>();
        //List<GetFirstName> firstNames = new List<GetFirstName>();
        //List<Twit> twit = new List<Twit>();
        //List<DaTwit> datwit = new List<DaTwit>();
        //List<ToSubscribe> subscribedUser = new List<ToSubscribe>();
        //List<ToFollow> toFollow = new List<ToFollow>();

        public IActionResult Index()
        {
            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var penguin = from u in _db.Users
            //              join t in _db.Twits on u.Id equals t.UserId
            //              join a in _db.SubscriedUsers on u.Id equals a.UserToFollow

            //              where u.Id == 1
            //              select new UserAndTwit { userVm = u, twitVm = t, subscribedUserVm = a, };
            //var author = _db.Twits;
            //var penguin = from a in _db.ToSubscribes
            //              join t in _db.Twits on a.TheUser equals t.UserId
            //              join u in _db.Users on t.UserId equals u.Id
            //              where a.UserToFollow == UserId

            //              select new UserAndTwit { userVm = u, daTwitVm = t, toSubscribeVm = a };

            //var penguin = from a in _db.ToFollows
            //              join tweet in _db.DaTwits on a.TheUser equals tweet.UserId
            //              join user in _db.Users on tweet.UserId equals user.Id
            //              where a.UserToFollow == UserId
            //              select a;
            var penguin = from a in _db.ToFollows
                          join tweet in _db.DaTwits on a.TheUser equals tweet.UserId
                          join u in _db.Users on tweet.UserId equals u.Id
                          where a.UserToFollow == UserId
                          select new UserAndTwit { primoNameVm = u, daTwitVm = tweet, toSubscribeVm = a };

            return View(penguin.ToList());

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Twit obj)
        {
            _db.Twits.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult pullTwits(string name)
        {
            IEnumerable<Twit> objList = _db.Twits;
            return Json(objList);
        }
        public JsonResult test(string name)
        {
            var potato = _db.Users;
            return Json(potato);
        }
        public JsonResult pullUsers(string name)
        {
            var objList = _db.Users;
            return Json(objList);
        }
        public JsonResult pullEnchiladas(string name)
        {
            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var daBird = from a in _db.ToFollows
                          join tweet in _db.DaTwits on a.TheUser equals tweet.UserId
                          join user in _db.Users on tweet.UserId equals user.Id
                          where a.UserToFollow == UserId
                          select tweet;
            return Json(daBird);
        }

        public class Person { public int ID { get; set; } public string Name { get; set; } public double Amount { get; set; } }

        public JsonResult GetTwits(int id)
        {
            var userId = _db.Twits
            .Where(p => p.UserId == id);
            
            
            return Json(userId);
        }

        [HttpPost]
        public JsonResult AsCreateSemester(ToFollow semester)
        {
            _db.ToFollows.Add(semester);
            _db.SaveChanges();
            return Json(semester);
        }


    }
}

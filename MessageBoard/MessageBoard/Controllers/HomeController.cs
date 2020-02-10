using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MessageBoard.Models;
using System.Runtime.Caching;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        ObjectCache cache = MemoryCache.Default;
        List<Posts> posts;

        public HomeController()
        {
            posts = cache["posts"] as List<Posts>;
            if (posts== null)
            {
                posts = new List<Posts>();
            }
        }
        public void SaveCache()
        {
            cache["posts"] = posts;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ViewPost(Posts Infos)
        {
            Posts list = new Posts();
            list.UserId = Infos.UserId;
            list.Name = Infos.Name;
            list.Content = Infos.Content;
            return View(posts);

        }
        public IActionResult CreatePost()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreatePost(Posts post)
        {
            posts.Add(post);
            SaveCache();

            return RedirectToAction("PostList");
            
        }
        public IActionResult PostList()
        { 

            return View(posts);
        }
    }
}

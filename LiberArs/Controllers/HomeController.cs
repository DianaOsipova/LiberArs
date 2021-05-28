using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using LiberArs.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.IO;




namespace LiberArs.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext _context;
        public HomeController(UserContext context)
        {
            this._context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            //  return Content(User.Identity.Name);
            return View();
        }

        [Authorize]
        public async Task<IActionResult> SearchPeople(string email)
        {
            if(email != null)
            {
                List<User> users = await _context.Users.Where(u => u.Email.Contains(email)).ToListAsync();
                               
                if(users != null)
                {
                    List<string> emails = new List<string>();

                    foreach(User u in users)
                    {
                        emails.Add(u.Email);
                    }

                    return View(emails);
                }
            }


            return RedirectToAction("Index");
            

        }

        public async Task<IActionResult> WatchPost(string email)
        {
            if(email != null)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user != null)
                {
                    List<Post> posts = await _context.Posts.Where(p => p.UserId == user.Id).ToListAsync();
                    ViewBag.email = email;
                    return View(posts);
                }
                 

            }
            return RedirectToAction("Index");
        }
    }
}

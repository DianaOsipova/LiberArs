using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using LiberArs.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;



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
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                
                if(user != null)
                {
                    var posts = _context.Posts.Where(u => u.UserId == user.Id);
                    return View(posts);
                }
            }


            return RedirectToAction("Index");
            

        }
    }
}

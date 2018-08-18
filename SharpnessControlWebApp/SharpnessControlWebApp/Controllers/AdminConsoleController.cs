using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using SharpnessControlWebApp.Models.Sharpness_Persistence.UserRepositoryExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SharpnessControlWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminConsoleController : Controller
    {
        private IUserRepo userRepo = new UserRepo();
        private EmailService service = new EmailService();
        private ApplicationDbContext _context = new ApplicationDbContext();
        //private IdentityMessage= new IdentityMessage(); 

        // GET: AdminConsole
        public ActionResult Index()
        {


            return View(userRepo.GetNotConfirmedUsers());
        }


        public async Task<ActionResult> ConfirmedRegistration(string Id)
        {
            var user = _context.Users.Find(Id);
            user.LockoutEndDateUtc = DateTime.UtcNow;
            _context.SaveChanges();

            var message = new IdentityMessage();
            message.Destination = user.Email;
            message.Subject = "USDP Kontofreigabe";
            message.Body = "Ihr Konto bei USDP ist jetzt ab " + DateTime.Now.ToString() + " freigegeben";
            await service.SendAsync(message);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DisallowRegistration(string Id)
        {
            var user = _context.Users.Find(Id);
            var message = new IdentityMessage();
            message.Destination = user.Email;
            message.Subject = "USDP Kontofreigabe";
            message.Body = "Ihre Registration bei USDP wurde am " + DateTime.Now.ToString() + " abgelehnt und gelöscht";
            await service.SendAsync(message);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        
    }
}
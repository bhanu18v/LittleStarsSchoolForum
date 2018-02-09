using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolForum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolForum.Controllers
{
    public class MessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messages
        public ActionResult Index(int?id)
        {          

            List<CategoryMessagesVM> model = new List<CategoryMessagesVM>();
           
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatName = category.CategoryName;


            foreach (Message ms in db.Messages.Where(m => m.CategoryId == id))
            {
                CategoryMessagesVM index = new CategoryMessagesVM();
              
                index.CategoryName = category.CategoryName;
                index.MessageId = ms.Id;
                index.MessageTitle = ms.MessageTitle;
                index.MessageDetails = ms.MessageDetails;
                index.PostedBy = ms.PostedBy;
                index.PostDateTime = ms.PostDateTime;

                model.Add(index);
            }
            
            return View(model);
        }

        public ActionResult IndexStr(int id, string test)
        {
            List<CategoryMessagesVM> model = new List<CategoryMessagesVM>();
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatName = category.CategoryName;


            foreach (Message ms in db.Messages.Where(m => m.UserId == test && m.CategoryId == id))
            {
                CategoryMessagesVM index = new CategoryMessagesVM();
                index.MessageId = ms.Id;
                index.MessageTitle = ms.MessageTitle;
                index.MessageDetails = ms.MessageDetails;
                index.PostedBy = ms.PostedBy;
                index.PostDateTime = ms.PostDateTime;

                model.Add(index);
            }

            return View(model);
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatName = category.CategoryName;
            return View();

        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MessageTitle,MessageDetails,PostDateTime,PostedBy")] Message message, int? id)
        {

            message.PostDateTime = DateTime.Now;
            //message.MessageCategory = db.Categories.FirstOrDefault(x => x.CategoryName == "Test");

            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ApplicationUser currentuser = UserManager.FindById(User.Identity.GetUserId());
            message.PostedBy = currentuser.Email;
            message.UserId = currentuser.Id;

            Category currentCategory = db.Categories.Find(id);
            message.CategoryId = currentCategory.Id;

            db.Messages.Add(message);
            db.SaveChanges();

            if (User.IsInRole("Teacher"))
            { 
                return RedirectToAction("Index", "Messages", new { id = currentCategory.Id });
            }
            else
             return RedirectToAction("IndexStr", "Messages", new {id=currentCategory.Id, test = message.UserId });
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MessageTitle,MessageDetails,PostedBy,PostDate")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).Property(x => x.PostDateTime).IsModified = false;
                db.Entry(message).State = EntityState.Modified;                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index","Categories");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

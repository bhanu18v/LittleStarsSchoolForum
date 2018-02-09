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
    public class RepliesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Replies
        public ActionResult Index(int?id)
        {
            List<MessageRepliesVM> model = new List<MessageRepliesVM>();
            //  var c = new CategoryMessagesVM();

            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.MesTitle = message.MessageTitle;

            foreach (Reply reply in db.Replies.Where(m => m.MessageId == id))
            {
                MessageRepliesVM index = new MessageRepliesVM();

                index.MessageTitle = message.MessageTitle;
                index.ReplyId = reply.Id;
                index.ReplyDetails = reply.ReplyDetails;
                index.ReplyPostedBy = reply.ReplyPostedBy;
                index.ReplyDateTime = reply.ReplyDateTime;

                model.Add(index);
            }
                return View(model);
        }

        // GET: Replies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // GET: Replies/Create
        public ActionResult Create(int?id)
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
           
            return View();
        }

        // POST: Replies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReplyDetails,ReplyPostedBy,ReplyDateTime,MessageId")] Reply reply, int? id)
        {           
                reply.ReplyDateTime = DateTime.Now;
 
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                ApplicationUser currentuser = UserManager.FindById(User.Identity.GetUserId());

                reply.ReplyPostedBy = currentuser.Email;
                reply.UserId = currentuser.Id;

                Message currentMessage = db.Messages.Find(id);
                reply.MessageId = currentMessage.Id;

                db.Replies.Add(reply);
                db.SaveChanges();
                return RedirectToAction("Index","Replies", new { id = currentMessage.Id });
           
        }

        // GET: Replies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // POST: Replies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReplyDetails,ReplyPostedBy,ReplyDateTime")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reply).Property(x => x.ReplyDateTime).IsModified = false;
                db.Entry(reply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reply);
        }

        // GET: Replies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // POST: Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Reply reply = db.Replies.Find(id);
            db.Replies.Remove(reply);
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

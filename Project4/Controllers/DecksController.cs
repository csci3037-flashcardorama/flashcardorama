using System;
using System.Collections.Generic;
using System.Data;

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project4;

namespace Project4.Controllers
{
    public class DecksController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: Decks
        //adapted from https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewBag.DateSortParm = sortOrder == "Author" ? "Card" : "Name";
            var decks = from s in db.Decks
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                decks = decks.Where(s => s.DeckName.Contains(searchString)
                                       || s.AspNetUser.UserName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name":
                    decks = decks.OrderByDescending(s => s.DeckName);
                    break;
                case "Author":
                    decks = decks.OrderByDescending(s => s.AspNetUser.UserName);
                    break;
                case "Card":
                    decks = decks.OrderByDescending(s => s.Cards);
                    break;
                default:
                    decks = decks.OrderByDescending(s => s.DeckName);
                    break;
            }
            return View(decks.ToList());
        }

        //// GET: Custom Search
        //public ViewResult Index(string q)
        //{
        //    var deck = from p in db.Decks select p;
        //    if (!string.IsNullOrWhiteSpace(q))
        //    {
        //        deck = deck.Where(p => (p.ToString()).Contains(q));
        //    }
        //    return View(deck);
        //}


        // GET: Decks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deck deck = db.Decks.Find(id);
            if (deck == null)
            {
                return HttpNotFound();
            }
            return View(deck);
        }

        // GET: Decks/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: Decks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeckName,AspNetUserId")] Deck deck)
        {
            if (ModelState.IsValid)
            {
                db.Decks.Add(deck);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "UserName", deck.AspNetUserId);
            return View(deck);
        }

        // GET: Decks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deck deck = db.Decks.Find(id);
            if (deck == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "UserName", deck.AspNetUserId);
            return View(deck);
        }

        // POST: Decks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeckName,AspNetUserId")] Deck deck)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deck).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "User", deck.AspNetUserId);
            return View(deck);
        }

        // GET: Decks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deck deck = db.Decks.Find(id);
            if (deck == null)
            {
                return HttpNotFound();
            }
            return View(deck);
        }

        // POST: Decks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deck deck = db.Decks.Find(id);
            db.Decks.Remove(deck);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		public ActionResult ChooseDeck()
		{
			dbEntities dbdc = new dbEntities();
			return View(dbdc.Decks.ToList());
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

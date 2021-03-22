using QuoteBank2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using QuoteBank2.ViewModels;
using System.Net;
using System.IO;

namespace QuoteBank2.Controllers
{
    public class QuotesController : Controller
    {
        public ApplicationDbContext _context = new ApplicationDbContext();

        public QuotesController()
        {
            //Parameterles Constructor
        }

        // GET: Quotes
        public ActionResult QuotesList(string searchString)
        {
            var _allData = _context.QuotesTBLs.Include(x => x.AuthorsTBL);

            //Linq query to get all reocrds/rows from quotes table
            //var allmovies = from m in _context.QuotesTBLs
            //                select m;


            if (!string.IsNullOrEmpty(searchString))
            {
                _allData = _allData.Where(x => x.Quote.Contains(searchString));
            }

            ViewBag.ListCount = _allData.ToList().Count;

            return View(_allData);
        }

        // GET: Quotes
        public ActionResult QuotesCardView()
        {
            var _allData = _context.QuotesTBLs.Include(x => x.AuthorsTBL);

            return View(_allData);
        }

        //------------------------------------------Authors List------------------------------------
        public ActionResult AuthorList(string searchString)
        {
            var allAuthors = _context.AuthorsTBLs;

            @ViewBag.AuthorCount = allAuthors.ToList().Count();

            return View(allAuthors);
        }

        //-------------------------------------------AddAuthor Starts Here--------------------------
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        //public ActionResult AddAuthor([Bind(Include = "AuthID, AuthorName, AuthorImage, ImageFile")] AuthorsTBL newAuthorsTBLObj)
        public ActionResult AddAuthor(AuthorFormViewModel authorFormViewModelObj) //No ViewModelNeeded - Just straight post to the database
        {
            if (ModelState.IsValid)
            {
                var newAuthorObj = new AuthorsTBL //Instantiated "NOT PASED" an object and put things into it via the view model

                {
                    AuthorName = authorFormViewModelObj.AuthorNameVM, //make an authornamefield,
                    //AuthorImage = authorFormViewModelObj.AuthorImageVM //AuthorImage Filename is now dealt with below...
                };

                string imagename = Path.GetFileNameWithoutExtension(authorFormViewModelObj.ImageFileVM.FileName);
                string extension = Path.GetExtension(authorFormViewModelObj.ImageFileVM.FileName);
                imagename = imagename + extension;
                newAuthorObj.AuthorImage = imagename;


                imagename = Path.Combine(Server.MapPath("~/Content/images/authors"), imagename);
                authorFormViewModelObj.ImageFileVM.SaveAs(imagename); //This uploads the image to the specified folder

                _context.AuthorsTBLs.Add(newAuthorObj);
                _context.SaveChanges();

                return RedirectToAction("NewAuthorSuccess", newAuthorObj);

            }

            return View();

        }
        //-----------------------------New Quote Add Alert Page----------------------------

        public ActionResult NewAuthorSuccess(AuthorsTBL newAuthorObj)
        {
            ViewBag.AlertAuthorName = newAuthorObj.AuthorName;

            ViewBag.AlertImagePath = newAuthorObj.AuthorImage;

            return View();
        }

        //---------------------------------------AddQuote Starts Here-----------------------------------
        [Authorize]
        public ActionResult AddQuote()
        {
                var viewModel = new QuoteFormViewModel
                {
                    AuthorsListable = _context.AuthorsTBLs.ToList()
                };
                ViewBag.ListToScreen = viewModel.AuthorsListable;

            return View();
        }

        [HttpPost]
        public ActionResult AddQuote([Bind(Include = "Quote, AuthorsTBLAuthID")] QuotesTBL newQuote)
        //public ActionResult AddQuote(QuotesTBL newQuote)
        {
            var viewModelobj = new QuoteFormViewModel
            {
                AuthorsListable = _context.AuthorsTBLs.ToList()

            };
            ViewBag.ListToScreen = viewModelobj.AuthorsListable; //Remember this is what shows the list of AuthorNames

            if (ModelState.IsValid)
            {                  
                _context.QuotesTBLs.Add(newQuote);
                _context.SaveChanges();

                return RedirectToAction("QuotesList", "Quotes");
            }
            return View(newQuote);
        }
        //--------------------------------------End AddQuote------------------------------------

        //---------------------------------------Edit Starts Here-------------------------------

        // GET: Products/Edit/5
        [Authorize]
        public ActionResult EditQuote(int? QuoteID)
        {
            //--------------------Can I get this to show up?-------------

            var viewModel = new QuoteFormViewModel
            {
                AuthorsListable = _context.AuthorsTBLs.ToList()

            };

            ViewBag.ListToScreen = viewModel.AuthorsListable; //Remember this is what shows the list of AuthorNames

            if (QuoteID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotesTBL selectedQuote = _context.QuotesTBLs.Find(QuoteID);

            if (selectedQuote == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AuthorID = new SelectList(_context.AuthorTBLs, "AuthID", "AuthorName", selectedQuote.AuthorID); Magic loosely typed DropDown
            return View(selectedQuote);
        }

        // POST: Products/Edit/5
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //more details see 
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public ActionResult EditQuote([Bind(Include = "QuoteID, Quote, AuthorsTBLAuthID")] QuotesTBL selectedQuote)
        {
            var viewModelobj = new QuoteFormViewModel
            {
                AuthorsListable = _context.AuthorsTBLs.ToList()

            };

            ViewBag.ListToScreen = viewModelobj.AuthorsListable;
            
            if (ModelState.IsValid)
            {
                _context.Entry(selectedQuote).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("QuotesList", "Quotes");
            }


            return View(selectedQuote);
        }

        // GET: QuoteGenPage
        public ActionResult QuotesPage()
        {
            var _allData = _context.QuotesTBLs.Include(x => x.AuthorsTBL);

            ViewBag.ListCount = _allData.ToList().Count;

            return View(_allData);
        }

        // GET: Quotes/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotesTBL selectedQuote = _context.QuotesTBLs.Find(id);
            if (selectedQuote == null)
            {
                return HttpNotFound();
            }
            return View(selectedQuote);
        }

        // POST: Quotes/Delete
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuotesTBL selectedQuote = _context.QuotesTBLs.Find(id);
            _context.QuotesTBLs.Remove(selectedQuote);
            _context.SaveChanges();
            return RedirectToAction("QuotesList");
        }
        //-----------------------------------------------------Delete Author--------------------------------

        // GET: Author/Delete
        public ActionResult DeleteAuthor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorsTBL selectedAuthor = _context.AuthorsTBLs.Find(id);
            if (selectedAuthor == null)
            {
                return HttpNotFound();
            }
            return View(selectedAuthor);
        }

        // POST: Author/Delete
        [Authorize]
        [HttpPost, ActionName("DeleteAuthor")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAuthorConfirmed(int id)
        {
            AuthorsTBL selectedAuthor = _context.AuthorsTBLs.Find(id);
            _context.AuthorsTBLs.Remove(selectedAuthor);
            _context.SaveChanges();
            return RedirectToAction("AuthorList");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
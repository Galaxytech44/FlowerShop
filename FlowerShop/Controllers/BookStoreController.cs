using FlowerShop.Models.BookEntityFramework;
using FlowerShop.Models;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerShop.Controllers
{
    public class BookStoreController : Controller
    {
        private BOOKSHOPEntitie database = new BOOKSHOPEntitie();  
        
        public ActionResult HomePage()
        {
            return View();
        }
        //selectedAuthor is the value of the author that was selected from the drop down
        public ActionResult Author(int? selectedAuthor = null)
        {
            //authors is used to hold all the values of the authors table into a list
            var authors = database.AUTHORs.ToList();
            //Authors is used to get the authors AUTHOR_NUM and AUTHOR_LAST from the authors table
            ViewBag.Authors = new SelectList(authors, "AUTHOR_NUM", "AUTHOR_LAST", selectedAuthor);
            //books is used to get the entire book database and filiter out all information with the selected author
            var books = selectedAuthor.HasValue
                        ? database.WROTEs.Where(w => w.AUTHOR_NUM == selectedAuthor.Value)
                                          .Select(w => w.BOOK)
                                          .ToList()
                        : new List<BOOK>();  
            //return view returns all of the information on the authors books
            return View(books);
        }
        //Inventory is the page where you can selected books by clicking on there images
        public ActionResult Inventory()
        {
            //books is used to hold the information of all books within the books database
            var books = database.BOOKs.Include("INVENTORies").Include("WROTEs").Include("PUBLISHER").ToList();
            //return is used to return the books database to be used in the webpage
            return View(books);
        }
        //Location is used to find books based off a book store location
        public ActionResult Location(int? selectedBranch = null)
        {
           //branches is used to get the information from the book database BRANCHes table and 
           //convert that data into a list
            var branches = database.BRANCHes.ToList();
            //Branches is used to hold the values of the branches table as a viewbag
            ViewBag.Branches = branches;
           //SelectedBranch is used to hold the values of the selectedBranched which is inputed by the user to get 
           //specific informtion on that store branch
            ViewBag.SelectedBranch = selectedBranch;
            //bookds is used to hold all of the data from the book database and sort out information that is from the selected store 
            //branch
            var books = selectedBranch.HasValue
                        ? database.INVENTORies.Where(i => i.BRANCH_NUM == selectedBranch.Value)
                                               .Select(i => i.BOOK)
                                               .ToList()
                        : new List<BOOK>(); 
            //Books is used to hold the ViewBag value to be used within the Location webpage of the book database information
            ViewBag.Books = books;
            return View();
        }
        //Publisher is the webpage used to look of books by there publisher
        public ActionResult Publisher(string selectedPublisher = null)
        {
            //publishers is used to hold all of the information on the PUBLISHERs table from the book database
            var publishers = database.PUBLISHERs.ToList();
            //Publishers is used to hold the selected publisher code and name of the selectedPublisher
            ViewBag.Publishers = new SelectList(publishers, "PUBLISHER_CODE", "PUBLISHER_NAME", selectedPublisher); 
            //books is used to hold all of the information on the selectedPublisher
            var books = string.IsNullOrEmpty(selectedPublisher)
                        ? new List<BOOK>()  
                        : database.BOOKs.Where(b => b.PUBLISHER_CODE == selectedPublisher).ToList();
            //Books is used to hold the values of all the information stored within the books database
            ViewBag.Books = books;
            //return View is used to return the books database on the Publisher webpage
            return View(books);
        }
        //BookDetials is used to view the information that is in a book
        public ActionResult BookDetials()
        {
            return View();
        }
        //Contact is webpage used to connact manage by sumbiting an AJAX enabled form
        public ActionResult Contact()
        {
            
            return View();
        }

      
    }
}
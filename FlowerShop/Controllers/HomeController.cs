using FlowerShop.Models.EntityFramework;
using FlowerShop.Models;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerShop.Controllers
{
   
    public class HomeController : Controller
    {
        //database is used to hold the Flower shop database
        private FLOWERSHOPEntitiess database = new FLOWERSHOPEntitiess();
        
        public ActionResult Index()
        {
            ViewBag.Message = "Home Page";
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Message = "New User Registration";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";
            return View();
        }
        public ActionResult AboutUs()
        {
            ViewBag.Message = "About Us";
            return View();
        }
        public ActionResult Legal()
        {
            ViewBag.Message = "Legal";
            return View();
        }
        public ActionResult ProjectOne(string searchTerm, string color, string size, string fromPrice,string toPrice, string buttonType)
        {
            //both boolian values isfilterVaild and issearchValid is used to check if the each section of the filters both search and filters are valid
            bool isfilterValid = true;
            bool issearchValid = true;
            //filterError and searchError are used to hold the error display values to be displayed in a viewbag message
            string filterError = null;
            string searchError = null;
            //theses are the viewbag messages that will be displaying the error within the partical view
            ViewBag.FilterError = filterError;
            ViewBag.SearchError = searchError;
            //if statement is used to check if the filter button has been clicked on
            if (buttonType == "Filter")
            {
                //the rest of these if statements are used to check if the values are null, empty or still at there defualt value
                if (string.IsNullOrEmpty(color) || color == "Please Select a Color")
                {
                    if (string.IsNullOrEmpty(size) || size == "Please Select a Size")
                    {
                        if (string.IsNullOrEmpty(fromPrice) || fromPrice == "From:" || string.IsNullOrEmpty(toPrice) || toPrice == "To:")
                        {
                            
                                filterError = "Please Check Your Filter Criteria";
                                isfilterValid = false;
                            
                        }
                    }
                }

                //the rest of these if statements are used to check if the values are null, empty or still at there defualt value
                if (!string.IsNullOrEmpty(fromPrice) && !string.IsNullOrEmpty(toPrice) && fromPrice != "From:" && toPrice != "To:")
                {
                    //fPrice is used to hold the fromPrice value
                    int fPrice = int.Parse(fromPrice);
                    //tPrice is used to hold the toPrice value
                    int tPrice = int.Parse(toPrice);
                    //if statement is used to see if the forPrice is greater than toPrice
                    if (fPrice > tPrice)
                    {
                        filterError = "Please Check Your Price Range";
                        isfilterValid = false;
                    }
                }
            }
            //if statement is used to check if the search button has been clicked on
            if (buttonType == "Search")
            {
                //the rest of these if statements are used to check if the values are null or empty
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchError = "Please Enter a Search Term";
                    issearchValid = false;
                }
                
            }
            //if statement checks if the Filter area is not valid
            if (!isfilterValid)
            {
                ViewBag.FilterError = filterError;

            }
            //if statement checks if the Search area is not vaild
            if (!issearchValid)
            {
                ViewBag.SearchError = searchError;
            }


            //namespaceConvert converts the users text input into the namespace input which is used in the flower table names
            String namespaceConvert(String input)
            {
                //lowerCase turns the input into all lower case letters
                String lowerCase = input.ToLower();
                //nameSpace is used to get the lower case string and find spaces then replaces the spaces with underscores
                String nameSpace = lowerCase.Replace(" ", "_");
                return nameSpace;
            }
            //flowers is used to hold all of the information within the FLOWER database
            var flowers = database.FLOWERs.AsQueryable();

            //all if statements are used to check if the string for the search filters are not null or if the search filters do not equal there defualt text value
            if (!string.IsNullOrEmpty(searchTerm))
            {
                //converted is used get the namespace once the searchTerm has been converted through the namespaceConvert() method
                String converted = namespaceConvert(searchTerm);
                //this statement is used to find flowers namespace names which contain some of the same letter values as the converted namespace
                flowers = flowers.Where(f => f.FLOWER_NAME.Contains(converted));
               

            }

            
            if (!string.IsNullOrEmpty(color) && color != "Please Select a Color")
            {
                //this statement is used to find color names within the FLOWER database which are equal to color
                flowers = flowers.Where(f => f.COLOR.COLOR_NAME == color);
            }

            
            if (!string.IsNullOrEmpty(size) && size != "Please Select a Size")
            {
                //this statement is used to find flower sizes within the FLOWER database which are equal to size
                flowers = flowers.Where(f => f.FLOWER_SIZE == size);
            }

            if (!string.IsNullOrEmpty(toPrice) && !string.IsNullOrEmpty(fromPrice) && toPrice != "To:" && fromPrice != "From:")
            {
                //these two int statements are used to convert fromPrice and toPrice into integers
                int fPrice = int.Parse(fromPrice);
                int tPrice = int.Parse(toPrice);
                //this statement gets the flower prices from the FLOWER database then gets flowers that are between the values fPrice and tPrice respectivily 
                flowers = flowers.Where(f => f.FLOWER_PRICE >= fPrice && f.FLOWER_PRICE <= tPrice);
            }
            
            return View(flowers.ToList());
        }





    }
}
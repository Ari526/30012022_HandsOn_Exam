using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookRecomendationBusinessLayer;
using BookRecomendationDTO;
using BookRecomendationWebApp.Models;
using Newtonsoft.Json;

namespace BookRecomendationWebApp.Controllers
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class RecomendBookController : Controller
    {
        // GET: RecomendBook
        public ActionResult Index()
        {
            return View();
        }



        public void AddReviews()
        {

        }

        public ActionResult DisplayResultsUsingWebAPI()
        {
            try
            {
                BookRecomendationBL blObj = new BookRecomendationBL();
                List<ReviewDTO> lstofReview = blObj.ShowReviewsForBook();
                List<BookViewModel> Mvc = new List<BookViewModel>();
                foreach (var review in lstofReview)
                {
                    BookViewModel newMvc = new BookViewModel();
                    newMvc.Book_ISBN = review.Book_ISBN;
                    newMvc.Review = review.Review;
                    newMvc.Rating = review.Rating;
                    lstofReview.Add(review);

                }
                return View(lstofReview);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }
    }
}
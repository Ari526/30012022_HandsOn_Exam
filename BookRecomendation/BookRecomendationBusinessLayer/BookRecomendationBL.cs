using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecomendationDataAccessLayer;
using BookRecomendationDTO;

namespace BookRecomendationBusinessLayer
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required. 
    public class BookRecomendationBL
    {
        BookRecomendationDAL dalObj;

        public BookRecomendationBL()
        {
            dalObj = new BookRecomendationDAL();

        }

        public List<ReviewDTO> ShowReviewsForBook()
        {
            var res = dalObj.FetchReviewsForBook();
            return res;
           
        }


        public int AddReviewForBook()
        {
            int add = dalObj.SaveReviewForBookToDB();
            return add;


        }
      
    }
}

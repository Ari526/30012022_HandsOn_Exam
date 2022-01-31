using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecomendationDTO;

namespace BookRecomendationDataAccessLayer
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class BookRecomendationDAL
    {
        BookRecomendationContext conObj;
        SqlConnection connecObj;
        SqlCommand cmdObj;
        public BookRecomendationDAL()
        {
            conObj = new BookRecomendationContext();
            connecObj = new SqlConnection(ConfigurationManager.ConnectionStrings["BooksConnectionStr"].ConnectionString);

        }


        public List<ReviewDTO> FetchReviewsForBook()
        {
            try
            {
                var result = conObj.Reviews.ToList();
                List<ReviewDTO> lstofReview = new List<ReviewDTO>();
                foreach (var item in result)
                {
                    lstofReview.Add(new ReviewDTO()
                    {
                        Book_ISBN = Convert.ToInt32(item.book_isbn),
                        Rating = Convert.ToInt32(item.rating),
                        Review = item.review1.ToString(),


                    });

                }
                return lstofReview;

            }
            catch (Exception)
            {

                throw;
            }

        }
        
        public int SaveReviewForBookToDB()
        {
            ReviewDTO revObj = new ReviewDTO(); 
            try
            {
                cmdObj = new SqlCommand();
                cmdObj.CommandText = @"uspAddReview";
                cmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                cmdObj.Connection = connecObj;
                cmdObj.Parameters.AddWithValue("@book_isbn", revObj.Book_ISBN);
                cmdObj.Parameters.AddWithValue("@rating", revObj.Review);
                cmdObj.Parameters.AddWithValue("@review1", revObj.Rating);
                SqlParameter returnvalue = new SqlParameter();
                returnvalue.Direction = ParameterDirection.ReturnValue;
                returnvalue.SqlDbType = SqlDbType.Int;
                cmdObj.Parameters.Add(returnvalue);
                SqlParameter outputValue = new SqlParameter();
                outputValue.Direction = ParameterDirection.Output;
                outputValue.SqlDbType = SqlDbType.Int;
                outputValue.ParameterName = "@book_isbn";
                cmdObj.Parameters.Add(outputValue);
                connecObj.Open();
                cmdObj.ExecuteNonQuery();
                return Convert.ToInt32(returnvalue.Value);




            }
            catch (Exception)
            {

                throw;
            }
        }

}
}

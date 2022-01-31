using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookRecomendationWebApp.Models
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class BookViewModel
    {

        public int Book_ISBN { get; set; }
        public int Rating { get; set; }

        public string Review { get; set; }
    }
}
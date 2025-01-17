﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookRecomendationDataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BookRecomendationContext : DbContext
    {
        public BookRecomendationContext()
            : base("name=BookRecomendationContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
    
        public virtual int uspAddBooks(string book_ISBN, string title, Nullable<int> edition, string author)
        {
            var book_ISBNParameter = book_ISBN != null ?
                new ObjectParameter("book_ISBN", book_ISBN) :
                new ObjectParameter("book_ISBN", typeof(string));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var editionParameter = edition.HasValue ?
                new ObjectParameter("edition", edition) :
                new ObjectParameter("edition", typeof(int));
    
            var authorParameter = author != null ?
                new ObjectParameter("author", author) :
                new ObjectParameter("author", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspAddBooks", book_ISBNParameter, titleParameter, editionParameter, authorParameter);
        }
    
        public virtual int uspAddReview(Nullable<int> book_isbn, Nullable<int> rating, string review)
        {
            var book_isbnParameter = book_isbn.HasValue ?
                new ObjectParameter("book_isbn", book_isbn) :
                new ObjectParameter("book_isbn", typeof(int));
    
            var ratingParameter = rating.HasValue ?
                new ObjectParameter("rating", rating) :
                new ObjectParameter("rating", typeof(int));
    
            var reviewParameter = review != null ?
                new ObjectParameter("review", review) :
                new ObjectParameter("review", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspAddReview", book_isbnParameter, ratingParameter, reviewParameter);
        }
    }
}

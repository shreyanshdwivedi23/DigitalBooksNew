using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReadersApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : Controller
    {

        DigitalBooksDBContext db; //= new DigitalBooksDBContext();
        private IConfiguration _config;
        public ReaderController(IConfiguration config, DigitalBooksDBContext _db)
        {
            _config = config;
            db = _db;
        }


        [HttpGet]
        [Route("viewBookDetails")]
        public TblBook viewBookDetails(int id)
        {
            try { 
            return (from b in db.TblBooks
                    join u in db.TblLogins on b.BookCreatedBy equals u.UserId
                    where b.BookId == id && b.BookIsActive == true
                    orderby b.BookId
                    select new TblBook
                    {
                        BookId = b.BookId,
                        BookTitle = b.BookTitle,
                        BookCategory = b.BookCategory,
                        BookPublisher = b.BookPublisher,
                        BookImage = b.BookImage,
                        BookPrice = b.BookPrice,
                        BookAuthor = u.UserPassword,
                        BookReleasedDate = b.BookReleasedDate,
                        BookContent = b.BookContent
                    }).Single();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("buyBook")]
        public IActionResult buyBook(int bookId, int readerId)
        {
            IActionResult response = Unauthorized();
            //book.BookCreatedDate = DateTime.Now;
            //db.TblBooks.Add(book);
            //db.SaveChanges();
            response = Ok();
            return response;
            //db.SaveChanges();
        }

        [HttpGet]
        [Route("getMyBooks")]
        public IEnumerable<TblBook> getMyBooks(int id)
        {
            //return (from b in db.TblBooks 
            //        join u in db.TblLogins on b.BookCreatedBy equals u.UserId
            //    ) 
            IActionResult response = Unauthorized();
            //book.BookCreatedDate = DateTime.Now;
            //db.TblBooks.Add(book);
            //db.SaveChanges();
            response = Ok();
            return db.TblBooks;
            //db.SaveChanges();
        }
    }
}

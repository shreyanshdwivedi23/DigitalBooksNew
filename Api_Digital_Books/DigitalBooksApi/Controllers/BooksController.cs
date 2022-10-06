using DigitalBooksApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DigitalBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        DigitalBooksDBContext db = new DigitalBooksDBContext();

        [HttpGet]
        [Route("getAllBooks")]
        public IEnumerable<TblBook> getAllBooks()
        {
            return db.TblBooks;
        }

        [HttpPost]
        [Route("addBook")]
        public IActionResult addBook([FromBody] TblBook book)
        {            
            IActionResult response = Unauthorized();
            book.BookCreatedDate = DateTime.Now;
            db.TblBooks.Add(book);
            db.SaveChanges();
            response = Ok();
            return response;            
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult upload()
        {
            var file = Request.Form.Files[0];
            var foldername = "Resources/Images";
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), foldername);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(foldername, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok(new { ImgPath = dbPath, Status = "Success" });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deleteBooks")]
        public IActionResult deleteBooks(int id)
        {
            var result = db.TblBooks.Where(x => x.BookId == id).FirstOrDefault();
            db.TblBooks.Remove(result);
            db.SaveChanges();
            return Ok(new { Status = "Success" });
            //db.SaveChanges();
        }

        [HttpPut]
        [Route("editBook")]
        public IActionResult Put([FromBody] TblBook obj)
        {
            var response = new { Status = "Success" };
            var existingBook = db.TblBooks.Where(x => x.BookId == obj.BookId)
                                                        .FirstOrDefault<TblBook>();

            if (existingBook != null)
            {
                obj.BookModifiedDate = System.DateTime.Now;
                existingBook.BookTitle = obj.BookTitle;
                existingBook.BookCategory = obj.BookCategory;



                if (obj.BookImage != "")
                {
                    existingBook.BookImage = obj.BookImage;
                }

                existingBook.BookPrice = obj.BookPrice;
                existingBook.BookPublisher = obj.BookPublisher;
                existingBook.BookIsActive = obj.BookIsActive;
                existingBook.BookContent = obj.BookContent;
                existingBook.BookReleasedDate = obj.BookReleasedDate;
                existingBook.BookModifiedDate = obj.BookModifiedDate;
                db.SaveChanges();
            }
            else
            {
                response = new { Status = "Not Found" };
                return Ok(response);
            }
            // response = new { Status = "Not Found" };
            return Ok(response);
        }

        [HttpPost]
        [Route("searchAllBooks")]
        public IEnumerable<TblBook> searchAllBooks(TblBook book)
        {
            List<TblBook> allAuthorBooks = new List<TblBook>();
            if (book.BookTitle != "" && book.BookPublisher != "")
            {
                allAuthorBooks = db.TblBooks.Where(x => x.BookTitle.Contains(book.BookTitle) && x.BookPublisher.Contains(book.BookPublisher)).ToList();
                return allAuthorBooks;
            }
            else if(book.BookTitle != "")
            {
                allAuthorBooks = db.TblBooks.Where(x => x.BookTitle.Contains(book.BookTitle)).ToList();
                return allAuthorBooks;
            }
            else if (book.BookPublisher != "")
            {
                allAuthorBooks = db.TblBooks.Where(x => x.BookPublisher.Contains(book.BookPublisher)).ToList();
                return allAuthorBooks;
            }
            else if (book.BookTitle != "" || book.BookPublisher != "")
            {
                allAuthorBooks = db.TblBooks.Where(x => x.BookTitle.Contains(book.BookTitle) || x.BookPublisher.Contains(book.BookPublisher)).ToList();
                return allAuthorBooks;
            }
            else
            {
                return db.TblBooks;
            }          
            
        }
    }
}

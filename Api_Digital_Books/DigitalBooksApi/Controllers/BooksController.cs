using Azure.Storage.Blobs;
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
        DigitalBooksDBContext db;

        public BooksController(DigitalBooksDBContext _db)
        {
            db = _db;
        }

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
        public async Task<IActionResult> upload()
        {

            //var file = Request.Form.Files[0];
            //var foldername = "Resources/Images/";
            //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), foldername);
            ////var pathToSave = Directory.GetCurrentDirectory();
            //if (file.Length > 0)
            //{
            //    try
            //    {
            //        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            //        var _filename = Path.GetFileNameWithoutExtension(fileName);
            //        fileName = _filename + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            //        var fullPath = Path.Combine(pathToSave, fileName);
            //        var dbPath = fileName;
            //        using (var stream = new FileStream(fullPath, FileMode.Create))
            //        {
            //            file.CopyTo(stream);
            //        }

            //        string connectionstring = "DefaultEndpointsProtocol=https;AccountName=digitalbookimages;AccountKey=hIhstj+zFMeTvf4MAIs1SlxEdAuCo6dZnsSf70vnPjIUxjyWQf8nMkwlLPPEj7t4ErJnFW6ACavd+AStKVlkNA==;EndpointSuffix=core.windows.net";
            //        string containerName = "images";
            //        BlobContainerClient container = new BlobContainerClient(connectionstring, containerName);
            //        var blob = container.GetBlobClient(fileName);
            //        var blobstream = System.IO.File.OpenRead("Resources/Images/" + fileName);
            //        await blob.UploadAsync(blobstream);
            //        var URI = blob.Uri.AbsoluteUri;

            //        return Ok(new { ImgPath = foldername + dbPath, Status = "Success" });
            var file = Request.Form.Files[0];
            //var foldername = "Resources/Images/";
            //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), foldername);
            //var pathToSave = Directory.GetCurrentDirectory();
            if (file.Length > 0)
            {
                try
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var _filename = Path.GetFileNameWithoutExtension(fileName);
                    fileName = _filename + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                    //var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = fileName;
                    //using (var stream = new FileStream(fullPath, FileMode.Create))
                    //{
                    //    file.CopyTo(stream);
                    //}

                    string connectionstring = "DefaultEndpointsProtocol=https;AccountName=digitalbookimages;AccountKey=hIhstj+zFMeTvf4MAIs1SlxEdAuCo6dZnsSf70vnPjIUxjyWQf8nMkwlLPPEj7t4ErJnFW6ACavd+AStKVlkNA==;EndpointSuffix=core.windows.net";
                    string containerName = "images";
                    BlobContainerClient container = new BlobContainerClient(connectionstring, containerName);
                    var blob = container.GetBlobClient(fileName);
                    var blobstream = file.OpenReadStream();
                    await blob.UploadAsync(blobstream);
                    var URI = blob.Uri.AbsoluteUri;

                    return Ok(new { ImgPath = dbPath, Status = "Success" });
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }

            //var file = Request.Form.Files[0];
            //var foldername = "Resources/Images";
            //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), foldername);
            //if (file.Length > 0)
            //{
            //    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            //    var fullPath = Path.Combine(pathToSave, fileName);
            //    var dbPath = Path.Combine(foldername, fileName);
            //    using (var stream = new FileStream(fullPath, FileMode.Create))
            //    {
            //        file.CopyTo(stream);
            //    }
            //    return Ok(new { ImgPath = dbPath, Status = "Success" });
            //}
            //else
            //{
            //    return BadRequest();
            //}
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
                existingBook.BookModifiedBy = obj.BookModifiedBy;
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
        public List<TblBook> searchAllBooks(TblBook book)
        {
            List<TblBook> listbook = new List<TblBook>();

            db.TblBooks.Where(x =>(String.IsNullOrEmpty(book.BookTitle) || x.BookTitle.Contains(book.BookTitle)) &&
            (String.IsNullOrEmpty(book.BookCategory) || x.BookCategory.Contains(book.BookCategory)) &&
            (String.IsNullOrEmpty(book.BookAuthor) || x.BookAuthor.Contains(book.BookAuthor)) &&
            (String.IsNullOrEmpty(book.BookPrice) || x.BookPrice.Equals(book.BookPrice))).Join(db.TblLogins.Where(l => (l.UserId == book.BookCreatedBy)), t => t.BookCreatedBy,
            k => k.UserId, (t, k) => new { t, BookUserName = k.UserName }).ToList().ForEach(o => {
                TblBook objtblbook = o.t;
                objtblbook.BookUserName = o.BookUserName;
                listbook.Add(objtblbook);
                });
            return listbook;

            //if (db.TblLogins.Any(x => x.UserName == book.BookAuthor) && book.BookAuthor != "")
            //{
            //    book.BookCreatedBy = Convert.ToInt32(db.TblLogins.Where(x => x.UserName == book.BookAuthor).Select(x => new {x.UserId}).FirstOrDefault());
            //    //db.TblLogins.Where(x => x.UserName == book.BookAuthor).FirstOrDefault();
            //}
            //List<TblBook> allAuthorBooks = new List<TblBook>();
            //if (book.BookTitle != "" && book.BookPublisher != "" && (book.BookCreatedBy !=null && book.BookCreatedBy != 0))
            //{
            //    allAuthorBooks = db.TblBooks.Where(x => x.BookTitle.Contains(book.BookTitle) && x.BookPublisher.Contains(book.BookPublisher) && x.BookPublisher.Equals(book.BookCreatedBy)).ToList();
            //    return allAuthorBooks;
            //}
            //else if(book.BookTitle != "")
            //{
            //    allAuthorBooks = db.TblBooks.Where(x => x.BookTitle.Contains(book.BookTitle)).ToList();
            //    return allAuthorBooks;
            //}
            //else if (book.BookPublisher != "")
            //{
            //    allAuthorBooks = db.TblBooks.Where(x => x.BookPublisher.Contains(book.BookPublisher)).ToList();
            //    return allAuthorBooks;
            //}
            //else if (book.BookCreatedBy != null && book.BookCreatedBy != 0)
            //{
            //    allAuthorBooks = db.TblBooks.Where(x => x.BookPublisher.Equals(book.BookCreatedBy)).ToList();
            //    return allAuthorBooks;
            //}
            //else if (book.BookTitle != "" || book.BookPublisher != "" || (book.BookCreatedBy != null && book.BookCreatedBy != 0))
            //{
            //    allAuthorBooks = db.TblBooks.Where(x => x.BookTitle.Contains(book.BookTitle) || x.BookPublisher.Contains(book.BookPublisher) || x.BookCreatedBy.Equals(book.BookCreatedBy)).ToList();
            //    return allAuthorBooks;
            //}
            //else
            //{
            //    return db.TblBooks;
            //}          

        }
    }
}

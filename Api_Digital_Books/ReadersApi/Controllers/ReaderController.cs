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
        public string buyBook(TblBookPurchase purchaseObj)
        {
            purchaseObj.OrderNo = "ODRN"+DateTime.Now.ToString("yyyyMMddHHmmss");
            purchaseObj.TblLogin.UserType = "Reader";
            purchaseObj.TblLogin.UserFullname = purchaseObj.TblLogin.UserName;
            db.TblLogins.Add(purchaseObj.TblLogin);
            db.SaveChanges();
            purchaseObj.ReaderId = purchaseObj.TblLogin.UserId; // Yes it's here
            purchaseObj.CreatedBy = purchaseObj.TblLogin.UserId; // Yes it's here
            db.TblBookPurchases.Add(purchaseObj);
            //response = Ok();
            
            db.SaveChanges();
            return purchaseObj.OrderNo;
        }

        [HttpGet]
        [Route("getMyBooks")]
        public List<TblBookPurchase> getMyBooks(TblLogin loginobj)
        {
            List<TblBookPurchase> listbook = new List<TblBookPurchase>();

            db.TblBooks
                .Join(db.TblLogins, b => b.BookCreatedBy,
            u => u.UserId, (b, u) => new { b, BookUserName = u.UserName })
                .Join(db.TblBookPurchases.Where(b => b.ReaderId == loginobj.UserId), bu => bu.b.BookId,
            p => p.BookId, (bu, p) => new { bu, p}).ToList().ForEach(bup => {
                TblBookPurchase objtblbook = bup.p;

                objtblbook.TblBook = bup.bu.b;
                objtblbook.TblBook.BookUserName = bup.bu.BookUserName;
                listbook.Add(objtblbook);
            });
            return listbook;
        }

        [HttpDelete]
        [Route("refundBook")]
        public string refundBook(TblBookPurchase purchaseObj)
        {
            db.TblBookPurchases.Remove(purchaseObj);
            db.SaveChanges();
            return "Refund completed successfully.";
        }
    }
}

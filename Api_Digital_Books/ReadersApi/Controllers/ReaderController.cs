using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReadersApi.Models;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : Controller
    {

        DigitalBooksDBContext db; //= new DigitalBooksDBContext();
        private IConfiguration _config;

        private readonly IBus bus;
   
        public ReaderController(IConfiguration config, DigitalBooksDBContext _db, IBus _bus)
        {
            _config = config;
            db = _db;
            bus = _bus;
        }


        [HttpGet]
        [Route("viewBookDetails")]
        public TblBook viewBookDetails(int id)
        {
            try
            {
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("buyBook")]
        public async Task<IActionResult> buyBook(TblBookPurchase purchaseObj)
        {
            purchaseObj.OrderNo = "ODRN" + DateTime.Now.ToString("yyyyMMddHHmmss");
            purchaseObj.tblLoginObj.UserType = "Reader";
            purchaseObj.tblLoginObj.UserFullname = purchaseObj.tblLoginObj.UserName;
            purchaseObj.tblLoginObj.UserPassword = "1234";
            db.TblLogins.Add(purchaseObj.tblLoginObj);
            db.SaveChanges();
            purchaseObj.ReaderId = purchaseObj.tblLoginObj.UserId; // Yes it's here
            purchaseObj.CreatedBy = purchaseObj.tblLoginObj.UserId; // Yes it's here
            db.TblBookPurchases.Add(purchaseObj);
            //response = Ok();
           
            db.SaveChanges();
            Uri uri = new Uri("rabbitmq:localhost/orderQueue");
            var endpoint = await bus.GetSendEndpoint(uri);
            TblBookPurchase orderMessage = new TblBookPurchase();
            orderMessage.OrderNo = purchaseObj.OrderNo;
            await endpoint.Send(orderMessage);
            //return Ok(new { status = "Your order is placed" });
            return Ok(new { Status = purchaseObj.OrderNo });
            //return ;
        }

        [HttpGet]
        [Route("getMyBooks")]
        public List<TblBookPurchase> getMyBooks(int id)
        {
            List<TblBookPurchase> listbook = new List<TblBookPurchase>();

            db.TblBooks
                .Join(db.TblLogins, b => b.BookCreatedBy,
            u => u.UserId, (b, u) => new { b, BookUserName = u.UserName })
                .Join(db.TblBookPurchases.Where(b => b.ReaderId == id), bu => bu.b.BookId,
            p => p.BookId, (bu, p) => new { bu, p }).ToList().ForEach(bup =>
            {
                TblBookPurchase objtblbook = bup.p;

                objtblbook.tblBookObj = bup.bu.b;
                objtblbook.tblBookObj.BookUserName = bup.bu.BookUserName;
                listbook.Add(objtblbook);
            });
            return listbook;
        }

        [HttpPut]
        [Route("refundBook")]
        public IActionResult refundBook([FromBody] TblBookPurchase purchaseObj)
        {
            var existingPurchase = db.TblBookPurchases.Where(x => x.PurchaseId == purchaseObj.PurchaseId).FirstOrDefault<TblBookPurchase>();

            if (existingPurchase != null)
            {
                existingPurchase = purchaseObj;
                existingPurchase.IsRefund = true;
            }
                //db.TblBookPurchases.Remove(purchaseObj);
            db.SaveChanges();
            
            return Ok(new { Status = "Refund completed successfully." });
        }

        [HttpPost]
        [Route("readerSearchAllBooks")]
        public List<TblBook> readerSearchAllBooks(TblBook book)
        {
            List<TblBook> listbook = new List<TblBook>();

            db.TblBooks.Where(x => (String.IsNullOrEmpty(book.BookTitle) || x.BookTitle.Contains(book.BookTitle)) &&
            (String.IsNullOrEmpty(book.BookCategory) || x.BookCategory.Contains(book.BookCategory)) &&
            (String.IsNullOrEmpty(book.BookAuthor) || x.BookAuthor.Contains(book.BookAuthor)) &&
            (String.IsNullOrEmpty(book.BookPrice) || x.BookPrice.Equals(book.BookPrice))).Join(db.TblLogins, t => t.BookCreatedBy,
            k => k.UserId, (t, k) => new { t, BookUserName = k.UserName }).ToList().ForEach(o =>
            {
                TblBook objtblbook = o.t;
                objtblbook.BookUserName = o.BookUserName;
                listbook.Add(objtblbook);
            });
            return listbook;
        }
    }
}

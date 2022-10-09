using MassTransit;
using Shared.Model;
using DigitalBooksApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBooksApi.Consumer
{
    public class paymentConsumer: IConsumer<Order>
    {
        DigitalBooksDBContext db = new DigitalBooksDBContext();
        public Task Consume(ConsumeContext<Order> context)
        {
            var data = context.Message;
            //var productdata = db.TblProducts.Where(x => x.Id == data.ProductId).FirstOrDefault();
            //productdata.Inventory = productdata.Inventory - data.Inventory;
            //db.TblProducts.Update(productdata);
            //db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

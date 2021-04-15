using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorPedramBackend.Jobs
{
    [DisallowConcurrentExecution]
    public class RemoveCartJobcs : IJob
    {
       
        public Task Execute(IJobExecutionContext context)
        {
            var option = new DbContextOptionsBuilder<DigikalaContext>();
            option.UseSqlServer(@"Server=.;Database=Didikala ;Trusted_Connection=true");
            using (DigikalaContext _context = new DigikalaContext(option.Options))
            {
                var order = _context.OrderProuducts.Where(o =>o.IsFainally==false && o.creatDate < DateTime.Now.AddDays(-1)).ToList();
                foreach (var item in order)
                {
                    var orderdetail = _context.DetailesOrders.Where(od => od.Ordeid == item.OrderProuductsid).ToList();
                    foreach (var item2 in orderdetail)
                    {
                        _context.Remove(item2);
                    }
                    _context.Remove(item);
                }
                _context.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}

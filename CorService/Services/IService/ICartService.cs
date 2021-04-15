using DataLayer.Entites.Cart;
using DataLayer.Entites.OrderProuduct;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Services.IService
{
   public interface ICartService
    {

        #region Order
        int AddOrder(int userid);
        bool AddOrderDetaile(int orderid, int productid);
        void UpdateSumOrder(int orderId);
        bool FindOpenOrder(OrderProuducts orderid, int id);
        OrderProuducts ShowOrderProuducts(int userid);
        List<OrderProuducts> getAllorderforAdmin();
        #endregion
    }
}

using Framework.Entities;
using Framework.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
    public interface ICartService
    {
        int GetCartCount(int cartId);
        CartModel GetCartDetails(int cartId);
        Cart AddItem(Guid UserId, int CartId, int ItemId, decimal UnitPrice, int Quantity);
        int DeleteItem(int cartId, int ItemId);
        int UpdateQuantity(int cartId, int id, int quantity);
        int UpdateCart(int CartId, Guid UserId);
    }
}

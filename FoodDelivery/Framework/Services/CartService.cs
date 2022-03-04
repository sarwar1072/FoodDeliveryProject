using Framework.Entities;
using Framework.Model;
using Framework.UnitOfworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Services
{
   public class CartService:ICartService
    {
        private readonly IShoppingUnitOfWork _shopingUnitOfWork;
        public CartService(IShoppingUnitOfWork shopingUnitOfWork)
        {
            _shopingUnitOfWork = shopingUnitOfWork;
        }
        //public Cart GetCart(int CartId)
        //{

        //    return _shopingUnitOfWork.CartRepository.Get(c=>c.Id==CartId && c.IsActive==true,"Items");
        //        //Include("Items").Where(c => c.Id == CartId && c.IsActive == true).FirstOrDefault();
        //}

       public Cart AddItem(Guid UserId, int CartId, int ItemId, decimal UnitPrice, int Quantity)
        {
            try
            {
                Cart cart = _shopingUnitOfWork.CartRepository.GetCart(CartId);
                if (cart == null)
                {
                    cart = new Cart();
                    CartItem item = new CartItem(ItemId, Quantity, UnitPrice);
                    cart.Id = CartId;
                    cart.UserId = UserId;
                    cart.CreatedDate = DateTime.Now;

                    item.CartId = cart.Id;
                    cart.Items.Add(item);
                    _shopingUnitOfWork.CartRepository.Add(cart);
                    _shopingUnitOfWork.Save();
                }
                else
                {
                    CartItem item = cart.Items.Where(p => p.ItemId == ItemId).FirstOrDefault();
                    if (item != null)
                    {
                        item.Quantity += Quantity;
                        _shopingUnitOfWork.CartItemRepository.Edit(item);
                        _shopingUnitOfWork.Save();
                    }
                    else
                    {
                        item = new CartItem(ItemId, Quantity, UnitPrice);
                        item.CartId = cart.Id;
                        cart.Items.Add(item);

                        _shopingUnitOfWork.CartItemRepository.Edit(item);
                        _shopingUnitOfWork.Save();
                    }
                }
                return cart;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int DeleteItem(int cartId, int ItemId)
        {
            return _shopingUnitOfWork.CartRepository.DeleteItem(cartId, ItemId);
        }

        public int GetCartCount(int cartId)
        {
            var cart = _shopingUnitOfWork.CartRepository.GetCart(cartId);
            return cart != null ? cart.Items.Count() : 0;
        }

        public CartModel GetCartDetails(int cartId)
        {
            var model = _shopingUnitOfWork.CartRepository.GetCartDetails(cartId);
            if (model != null && model.Items.Count > 0)
            {
                decimal subTotal = 0;
                foreach (var item in model.Items)
                {
                    item.Total = item.UnitPrice * item.Quantity;
                    subTotal += item.Total;
                }
                model.Total = subTotal;
                //5% tax
                model.Tax = Math.Round((model.Total * 5) / 100, 2);
                model.GrandTotal = model.Tax + model.Total;
            }
            return model;
        }

        public int UpdateCart(int CartId, Guid UserId)
        {
            return _shopingUnitOfWork.CartRepository.UpdateCart(CartId, UserId);
        }

        public int UpdateQuantity(int cartId, int id, int quantity)
        {
            return _shopingUnitOfWork.CartRepository.UpdateQuantity(cartId, id, quantity);
        }
    }
}

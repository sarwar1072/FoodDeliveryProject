using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public class PaymentDetailsRepository: Repository<PaymentDetails, string, ShopingContext>, IPaymentDetailsRepository
    {
        public PaymentDetailsRepository(ShopingContext shopingContext) :base(shopingContext)
        {
        }

    }
}

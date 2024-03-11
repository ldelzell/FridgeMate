using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class CheckoutManager
    {
        public ICheckoutDataAccess data;

        public CheckoutManager(ICheckoutDataAccess data)
        {
            this.data = data;
        }
        public bool CreateCheckout(Checkout checkout) { 
            return data.CreateCheckout(checkout);
        }
    }
}

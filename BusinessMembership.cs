using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_with_Objects
{
    public class BusinessMembership : Membership
    {
        public override double CalculateDiscount(double amount)
        {
            return amount * 0.8; // 20% discount for Business members
        }

        private double CalculateTotalAmount(User user)
        {
            double totalAmount = 0;

            foreach (Product product in user.ShoppingCart.Products)
            {
                totalAmount += product.Price;
            }

            // Apply membership discount if applicable
            if (user.Membership != null)
            {
                double discount = user.Membership.CalculateDiscount(totalAmount);
                totalAmount -= discount;

            }

            return totalAmount;
        }
    }
}

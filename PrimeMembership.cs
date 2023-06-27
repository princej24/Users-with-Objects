using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_with_Objects
{
    public class PrimeMembership : Membership
    {
        public override double CalculateDiscount(double amount)
        {
            return amount * 0.9; 
        }
    }
}

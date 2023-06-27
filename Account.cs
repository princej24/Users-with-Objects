using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_with_Objects
{
    public  class Account
    {
       
        
            public List<string> ShoppingHistory { get; set; }

            public Account()
            {
                ShoppingHistory = new List<string>();
            }
        
    }
}

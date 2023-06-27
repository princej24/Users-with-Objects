using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_with_Objects
{
    public class User
    {
        public string Username { get; set; }
        public Account Account { get; set; }
        public Membership Membership { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public User(string username, Membership membership)
        {
            Username = username;
            Membership = membership;
            Account = new Account();
            ShoppingCart = new ShoppingCart();
        }
    }
}

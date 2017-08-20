using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Cineplex.Models
{
    public class CartItem : System.Collections.IEnumerable
    {
        public Session session { get; set; }
        public int quantity { get; set; }
        //public ArrayList seats { get; set; }

        public CartItem()
        {
            //seats = new ArrayList();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /*public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }*/
    }
}

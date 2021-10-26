using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Item> Cart { get; set; }

        public Buyer(int id, string name)
        {
            Id = id;
            Name = name;
            Cart = new List<Item>();
        }

        public void AddItem(Item item, int itemQuantity)
        {
            this.Cart.Add(new Item(item.Id,item.Name,itemQuantity));
        }
    }
}

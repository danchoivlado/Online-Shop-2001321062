using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }

        public void Order(int itemId, int orderedItemQuantity, Buyer buyer)
        {
            Item item = this.Items.FirstOrDefault(item => item.Id == itemId);
            if (item == null)
            {
                Console.WriteLine($"Item with id: {itemId} doesn't exists.");
                return;
            }

            item.DecreaseQuantity(orderedItemQuantity);
            buyer.AddItem(item, orderedItemQuantity);
        }

        public Shop(int id, string name, List<Item> items)
        {
            Id = id;
            Name = name;
            Items = items;
        }
    }
}

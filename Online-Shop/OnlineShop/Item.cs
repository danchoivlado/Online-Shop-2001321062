using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Supplier Owner { get; set; }

        public void DecreaseQuantity(int decreaseAmount)
        {
            if (this.Quantity - decreaseAmount < 0)
            {
                Console.WriteLine("Cannot decrease with that amount");
                return;
            }
            this.Quantity -= Math.Abs(decreaseAmount);
        }

        public void IncreaseQuantity(int increaseeAmount)
        {
            this.Quantity += Math.Abs(increaseeAmount);
        }

        public Item(int id, string name, int quantity, Supplier owner = null)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Owner = owner;
        }
    }
}

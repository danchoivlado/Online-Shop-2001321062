using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Supplier(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

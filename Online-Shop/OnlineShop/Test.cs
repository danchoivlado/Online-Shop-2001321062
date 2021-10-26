using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop
{
    class Test
    {
        private List<Buyer> buyers;
        private Shop shop;
        private List<Supplier> suppliers;
        public void Run()
        {
            GenerateData();

            List<Thread> threads = getTheadsList();
            foreach (var t in threads) t.Join();
        }

        private List<Thread> getTheadsList()
        {
            List<Thread> threads = new List<Thread>();

            Thread buyersThread = new Thread(BuyersBuyProducts);
            threads.Add(buyersThread);
            buyersThread.Start();

            Thread supliersThread = new Thread(SupliersStockProducts);
            threads.Add(supliersThread);
            supliersThread.Start();

            return threads;
        }

        private void SupliersStockProducts()
        {
            lock (this)
            {
                foreach (var supplier in suppliers)
                {
                    List<Item> suplierItems = shop.Items.Where(item => item.Id == supplier.Id).ToList();
                    foreach (var suplierItem in suplierItems)
                    {
                        suplierItem.IncreaseQuantity(50);
                    }
                }
            }
        }

        private void BuyersBuyProducts()
        {
            lock (this)
            {
                Random rnd = new Random();

                foreach (var buyer in buyers)
                {
                    int itemId = rnd.Next(1, shop.Items.Count + 1);
                    int itemOrderCount = rnd.Next(1, 6);
                    shop.Order(itemId, itemOrderCount, buyer);
                }
            }
        }

        private void GenerateData()
        {
            Task<List<Buyer>> buyersTask = new Task<List<Buyer>>(GenerateBuyers);
            buyersTask.Start();
            Task<List<Supplier>> suplierTask = new Task<List<Supplier>>(GenerateSupliers);
            suplierTask.Start();
            suppliers = suplierTask.Result;
            Task<List<Item>> itemsTask = new Task<List<Item>>(() => GenerateItems(suppliers));
            itemsTask.Start();

            shop = new Shop(1, "Lidl", itemsTask.Result);
            buyers = buyersTask.Result;
        }

        private List<Buyer> GenerateBuyers()
        {
            List<Buyer> buyers = new List<Buyer>();
            for (int i = 1; i <= 100; i++)
            {
                buyers.Add(new Buyer(i, $"Buyer {i}"));
            }

            return buyers;
        }

        private List<Item> GenerateItems(List<Supplier> suppliers)
        {
            List<Item> items = new List<Item>();
            int globalIncreaser = 1;
            foreach (var suplier in suppliers)
            {
                for (int i = 1; i <= 5; i++)
                {
                    items.Add(new Item(globalIncreaser, $"Item {globalIncreaser}", 50, suplier));
                    globalIncreaser++;
                }

            }

            return items;
        }

        private List<Supplier> GenerateSupliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            for (int i = 1; i <= 5; i++)
            {
                suppliers.Add(new Supplier(i, $"Supplier {i}"));
            }

            return suppliers;
        }
    }
}

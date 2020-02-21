﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesignDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //4
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);

            StockController stockController = new StockController();
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.TakeOrder(buyStock);

            stockController.PlaceOrders();
            Console.ReadLine();
            //
        }
    }

    //1
    class StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 10;

        public void Buy()
        {
            Console.WriteLine("Stock:{0} , {1} bought!", _name, _quantity);
        }

        public void Sell()
        {
            Console.WriteLine("Stock:{0} , {1} sold!", _name, _quantity);
        }
    }
    //

    //2 Komutlarımızı nesne haline getirdik.
    interface IOrder 
    {
        void Execute();
    }
    class BuyStock : IOrder //Komutumuz
    {
        private StockManager _stockManager;
        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Buy();
        }
    }
    class SellStock : IOrder //Komutumuz
    {
        private StockManager _stockManager;
        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }


        public void Execute()
        {
            _stockManager.Sell();
        }
    }
    //

    //3
    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();
        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute(); 
            }

            _orders.Clear();
        }
    }
    //
}

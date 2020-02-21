using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //8
            var customerObserver = new CustomerObserver();
            ProductManager productManager = new ProductManager();
            //detach eklediğimiz için attach customer'ı sildik
            //productManager.Attach(new CustomerObserver());
            productManager.Attach(new EmployeeObserver());
            productManager.Detach(customerObserver);
            productManager.UpdatePrice();
            Console.ReadLine();
            //
        }
    }

    //1
    class ProductManager
    {
        //5
        List<Observer> _observers = new List<Observer>();

        //
        public void UpdatePrice()
        {
            Console.WriteLine("Product Price Changed");
            //7
            Notify();
            //
        }
        //6
        public void Attach(Observer observer) //listeye ekle
        {
            _observers.Add(observer);
        }
        public void Detach(Observer observer) //listeden çıkar
        {
            _observers.Remove(observer);
        }

        private void Notify() //bilgilendirici
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
        //
    }
    //

    //2
   abstract class Observer
    {
        public abstract void Update();
    }
    //

    //3
    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Customer: Product Price Changed");
        }
    }
    //

    //4
    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Employee: Product Price Changed");
        }
    }
    //
}

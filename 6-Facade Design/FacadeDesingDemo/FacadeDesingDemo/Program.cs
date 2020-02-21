using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //10
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
            //
        }
    }
    //1
    class Logging: ILoging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

     interface ILoging
    {
        void Log();
    }
    //

    //2
    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }
     interface ICaching
    {
        void Cache();
    }
    //

    //3
    class Authorize: IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked");
        }
    }
    interface IAuthorize
    {
        void CheckUser();
    }
    //

    //4
    class CustomerManager
    {
        //7
        private CrossCuttongConcernsFacade _concerns;
        //

        public CustomerManager()
        {
            //8
            _concerns = new CrossCuttongConcernsFacade();
            //
        }
        //5
        public void Save()
        {
            //9
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            _concerns.Logging.Log();
           //
            Console.WriteLine("Saved");
        }
        //
    }
    //

    //6
    class CrossCuttongConcernsFacade
    {
        public ILoging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public CrossCuttongConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }
    }
    //
}

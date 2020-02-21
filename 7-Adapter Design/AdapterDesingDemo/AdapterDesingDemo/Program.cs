using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //8
            //ProductManager productManager = new ProductManager(new EdLogger());
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadLine();
            //
        }
    }
    //1
    class ProductManager
    {
        //4
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        //
        public void Save()
        {
            //5
            _logger.Log("User Data");
            //
            Console.WriteLine("Saved");
        }
    }
    //

    //2
    interface ILogger
    {
        void Log(string message);
    }
    //

    //3
    class EdLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged,{0}",message);
        }
    }
    //

    //6 (Nugget'den indirdiğini varsay , müdahale edemiyorsun)
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net,{0}", message);
        }
    }
    //

    //7
    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
    //
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObjectDesignDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //6
          /*  CustomerManager customerManager = new CustomerManager(new NLogLogger()); */CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
            Console.ReadLine();
            //
        }
    }

    //1
    class CustomerManager
    {
        //4
        private ILogger _logger;
        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }
        //

        //5
        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
        //
    }
    //

    //2
    interface ILogger
    {
        void Log();
    }
    //

    //3
    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logg With Log4NetLogger");
        }
    }
    class NLogLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logg With NLogLogger");
        }
    }
    //

    //7 Case:Test kodu yazma
    class CustomerManagerTests
    {
        public void saveTest()
        {
            //log4netlogger bağlılığından kurtulmamız gerek
            //CustomerManager customerManager = new CustomerManager(new Log4NetLogger()); 

            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());//sahte bir ILogger göndermemiz gerek
            customerManager.Save();
        }
    }
    //

    //8
    class StubLogger : ILogger
    {
        private static StubLogger _stubLogger;
        private static object _lock = new object();
        private StubLogger()
        {

        }
        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubLogger==null)
                {
                    _stubLogger = new StubLogger();
                }
            }
            return _stubLogger;
        }
        public void Log()
        {
            
        }
    }
    //
}

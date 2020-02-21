using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //15
            ProductManager _productManager = new ProductManager(new Factory1());

            _productManager.GetAll();
            Console.ReadLine();

        }
        //1.
        public abstract class Logging
        {
            public abstract void Log(string message);
        }

        //2.
        public class Log4NetLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with Log4Net");
            }
        }

        //3.

        public class NLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with nLogger");

            }
        }

        //4.
        public abstract class Caching
        {
            public abstract void Cache(string data);
        }

        //5.

        public class MemCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with MemCache");
            }
        }

        //6.
        public class RedisCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with RedisCache");
            }
        }

        //7.Fabrika kurumu

        public abstract class CrossCuttingConcernsFactory
        {
            public abstract Logging CreateLogger();
            public abstract Caching CreateCaching();
        }

        //8. CrossCuttingConcernsFactory'den yeni Factory üretmek

        public class Factory1 : CrossCuttingConcernsFactory
        {
            public override Caching CreateCaching()
            {
                return new RedisCache();
            }

            public override Logging CreateLogger()
            {
                return new Log4NetLogger();
            }
        }

        //9. Factory2
        public class Factory2 : CrossCuttingConcernsFactory
        {
            public override Caching CreateCaching()
            {
                return new MemCache();
            }

            public override Logging CreateLogger()
            {
                return new NLogger();
            }
        }

        //10. İş katmanı

        public class ProductManager
        {
            //11
            private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;

            //12
            Logging _logging;
            Caching _caching;
            //

            //11.1
            public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
            {
                _crossCuttingConcernsFactory = crossCuttingConcernsFactory;

                //13
                _logging = crossCuttingConcernsFactory.CreateLogger();
                _caching = _crossCuttingConcernsFactory.CreateCaching();
                //
            } 

            //10
            public void GetAll()
            {
                //12
                //_crossCuttingConcernsFactory.CreateLogger().Log();
                //

                //14
                _logging.Log("Logged");
                _caching.Cache("Data");
                //
                Console.WriteLine("Product Listed");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDemo 
    //En sık kullanılanlardan. Amaç: Yazılımdaki değişimi kontrol altında tutmaktır. ORM,Cash,Loglama sistemleri...

{
    class Program
    {
        static void Main(string[] args)
        {
            //kullanım senaryosu
            //10
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    //1-class oluşturuldu , Loglama yapacak sınıf 
    public class LoggerFactory : ILoggerFactory //4-Ilogger factory oluşturuldu 
    {
        public ILogger CreateLogger() //2- Factory method yazılımı
        {
            return new EdLogger(); //7-
        }
    }

    public interface ILoggerFactory //5.Interface oluşturuldu
    {
    }

    public interface ILogger  //3-Bir interface oluşturuldu.
    {
        void Log();
    }

    //6- Bir logger'ımız olduğunu düşünelim
    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger");
            //Console.ReadLine();
        }
    }
    

    //8-
    public class CustomerManager
    {
        //9 
        public void Save()
        {
            Console.WriteLine("Saved");
            //Console.ReadLine();
            //ILogger logger = new EdLogger(); //yalnış kullanım edlogger'a bağlı kalmış olduk.
            ILogger logger = new LoggerFactory().CreateLogger();
            logger.Log();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomerManager manager = new CustomerManager();  şeklinde yazarasak bize hata verir.

            var customerManager = CustomerManager.CreateAsSingleton(); //şeklinde yazabiliriz.Nesne 1 kere üretebilinir.
            //customerManager. denildiğinde kullanılabilecek işlemler gelir.

            customerManager.Save(); //6.
        }
    }

    class CustomerManager //class oluşturuldu.
    {
        static CustomerManager _customerManager; //3.1yöneteceğimiz nesne
        static object _lockObject = new object();        //6. İf'li kısmın 1 kere işlendiğinden emin olmak için.

        //1-önce nesnenin private ctor'unun oluşturulmalıdır. Amaç dış erişime engellemektir. Yani ctor'u var ama dışarıdan erişilemeyen bir nesne oluşturuyoruz.
        private CustomerManager()
        {

        }
        //2-sonraki adım singleton örneği için bir metod yazmaktır.
        public static CustomerManager CreateAsSingleton() //customermanager'in kendisini döndürür
        {
            //3-customermanagerin daha önce oluşturulmuşu varsa onu vericez. Eğer yoksa bir tane oluşturup onu döndüreceğiz. Bir tane yöneteceğimiz nesneye ihtiyacımız var. 

            lock (_lockObject) //6.1
            {
                if (_customerManager == null) //4.
                {
                    _customerManager = new CustomerManager(); //Customer manager yoksa oluştur.
                }

            }

            return _customerManager;
        }


        public void Save() // 5-Bir Metod yazacak olursak;
        {
            Console.WriteLine("Has been Saved!");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyDesingDemo
{
    //Bir cacheleme sistemine benzetilebilir. Bir sınıfın çağırdığı bir işlem var , ilk kez çağırıldığında o işlemi yapacak , fakat ikinci kez çağırıldığında daha önce çağırılmışsa onu kullanma sürecinde bulunan bir yapıdır.
    //Mevzu; bizim çağırmak istediğimiz operasyon sonucu sabit olan bir hesaplamaysa ve ya kaynaksa , o kaynağı bir daha çağırmamak adına kullanılan bir süreçtir.
    //Bir hesap yaptığımızda bu hesabın sonucunu bir daha kullanmak istediğimizde nasıl hızlıca erişeceğimizi göstereceğiz.
    class Program
    {
        static void Main(string[] args)
        {
            //3
            //CreditManager manager = new CreditManager();
            //Console.WriteLine(manager.Calculate());
            //Console.WriteLine(manager.Calculate());

            //Console.ReadLine();
            //

            //5
            CreditBase manager = new CreditManagerProxy();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());

            Console.ReadLine();
            //
        }
    }
    //1
    abstract class CreditBase
    {
        public abstract int Calculate();

    }
    //

    //2
    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }
    //

    //4 : ProxyDesign 
    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
            if (_creditManager==null)
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }
            return _cachedValue;
        }
    }
    //
}

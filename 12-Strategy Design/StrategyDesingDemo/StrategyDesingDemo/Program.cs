using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //4
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculaterBase = new After2010CreditCalculater();
            customerManager.SaveCredit();

            customerManager.CreditCalculaterBase = new Before2010CreditCalculater();
            customerManager.SaveCredit();
            Console.ReadLine();
            //
        }
    }

    //1
   abstract class CreditCalculaterBase
    {
        public abstract void Calculate();
    }
    //

    //2
    class Before2010CreditCalculater : CreditCalculaterBase
    {
        public override void Calculate()
        {
          Console.WriteLine("Calculated before 2010");
        }
    }
    class After2010CreditCalculater : CreditCalculaterBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Calculated after 2010");
        }
    }
    //

    //3
    class CustomerManager
    {
        public CreditCalculaterBase CreditCalculaterBase{ get; set; }
        public void SaveCredit()
        {
            Console.Write("Customer Manager Business");
            CreditCalculaterBase.Calculate();
        }
    }
    //
}

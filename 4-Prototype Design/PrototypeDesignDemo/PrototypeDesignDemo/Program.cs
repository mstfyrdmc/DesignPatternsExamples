using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesignDemo // amaç: nesne üretim maaliyetini minimize etmektir.
{
    class Program
    {
        static void Main(string[] args)
        {
            //5
            Customer customer1 = new Customer { FirstName = "Engin", LastName = "Demirog", City = "Ankara", ID = 1 };
            

            var customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Salih";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);
            Console.ReadLine();
        }
    }
    //1.
    public abstract class Person
    {
        //2.
        public abstract Person Clone();
        //
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    //

    //3.
    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
            //throw new NotImplementedException();
        }
    }

    //4
    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
            //throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesingDemo
{
    //Nesneler arası hiyerarşi , bu nesnelere istenilen zamanda ulaşabilmek
    class Program
    {
        static void Main(string[] args)
        {
            //5 (ayse ve mehmet, mustafa'nın altında çalışıyor , ahmetin altında fatma çalışıyor.)
            Employee mustafa = new Employee {Name= "Mustafa Yardımcı" };
          

            Employee ahmet = new Employee {Name= "Ahmet Mehmetoglu" };
        
            mustafa.AddSubOrdinate(ahmet);

            Employee ayse = new Employee { Name = "Ayse Demir" };
            mustafa.AddSubOrdinate(ayse);

            //7
            Contractor ali = new Contractor { Name = "Ali" };
            ayse.AddSubOrdinate(ali);
            //

            Employee fatma = new Employee {Name= "Fatma Tahta" };
            ahmet.AddSubOrdinate(fatma);
            Console.WriteLine(mustafa.Name);
            foreach (Employee manager in mustafa)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employee in manager) //Aliyi göstermek içi Iperson yazdık
                {
                    Console.WriteLine("    {0}",employee.Name);

                }
            }
            Console.ReadLine();
            //
        }
    }

    //6
    class Contractor : IPerson
    {
        public string Name { get; set; }
    }
    //

    //1
    interface IPerson
    {

         string Name { get; set; }
    }
    //

    //2
    class Employee : IPerson,IEnumerable<IPerson> //foreach ile gezebileceğimiz bir ortam oluşturduk ()IEnumerable ile
    {
        //3
        List<IPerson> _subordinates = new List<IPerson>();
        public void AddSubOrdinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubOrdinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubOrdinate(int index)
        {
            return _subordinates[index];
        }
        //
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            //4
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;  //IEnumerator tipinde olması dönüş olması için yield kullanıldı.
            }
           //
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //
}

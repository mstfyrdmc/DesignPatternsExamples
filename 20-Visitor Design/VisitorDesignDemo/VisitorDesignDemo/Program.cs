using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorDesignDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //9
            Manager mustafa = new Manager {Name="Mustafa",Salary=3000 };
            Manager salih = new Manager {Name="Salih",Salary=2500 };
            Worker ayse = new Worker {Name="Ayşe",Salary=1500 };
            Worker ali = new Worker {Name="Ali",Salary=1400 };

            mustafa.SubOrdinates.Add(salih); //mustafanın bir altında salih var.
            salih.SubOrdinates.Add(ayse);   // salihin bir altına ayse var.
            salih.SubOrdinates.Add(ali); //salihin bir altında ali var.

            OrganizationStructure organizationStructure = new OrganizationStructure(mustafa);
            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayRiseVisitor payRiseVisitor = new PayRiseVisitor();

            organizationStructure.Accept(payrollVisitor);
            organizationStructure.Accept(payRiseVisitor);

            Console.ReadLine();
            //
        }
    }

    //1
    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }


    }
    abstract class VisitorBase 
    {
        //public abstract void Visit();

        //6
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
        //
    }
    //5
    class PayrollVisitor : VisitorBase
    {
        //7
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
        //
    }
    //

    //8
    class PayRiseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary rised to {1}", worker.Name, worker.Salary*(decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary rised to {1}", manager.Name, manager.Salary*(decimal)1.2);
        }
    }
    //
    class Manager : EmployeeBase
    {
        //3
        public Manager()
        {
            SubOrdinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> SubOrdinates { get; set; }
        //
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            //4
            foreach (var employee in SubOrdinates)
            {
                employee.Accept(visitor);
            }
            //
        }
    }
    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
  
    class OrganizationStructure //kurum yapısı
    {
        public EmployeeBase Employee;
        public OrganizationStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }
        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

   
    //
}

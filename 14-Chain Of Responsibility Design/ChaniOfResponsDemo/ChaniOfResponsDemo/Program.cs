using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaniOfResponsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //4
            Manager manager = new Manager();
            VicePrsident vicePrsident = new VicePrsident();
            President president = new President();

            //üstlerini tanımladık.
            manager.SetSuccessor(vicePrsident);
            vicePrsident.SetSuccessor(president);

            Expense expense = new Expense { Detail = "Train", Amount = 2000 };
            manager.HandleExpense(expense);
            Console.ReadLine();
            //
        }
    }

    //1
    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }
    //

    //2
    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpense(Expense expense);
        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }
    //

    //3
    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount<=100)
            {
                Console.WriteLine("Manager Handled the expend");
            }
            else if(Successor!=null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
    class VicePrsident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount<=1000)
            {
                Console.WriteLine("VP Handled the expend");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount >1000)
            {
                Console.WriteLine("President Handled the expend");
            }
            
        }
    }
    //
}

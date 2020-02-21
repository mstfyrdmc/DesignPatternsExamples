using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesingDemo
    //Ortaya bir nesne örneği çıkarmayı hedefler. Bu nesne örneği birbiri ardına atılan adımların sırasıyla işlenmesiyle ortaya çıkar. Genellikle arayüz ve ya iş katmanlarında kodları if le yazmak yerine ilgili üreticinin enjekte edilmesi ve onunla ilgili ortaya bir nesne çıkarılması şeklinde örneklendiririz.

    //Bir hamburger üretimine benzetebiliriz. Hamburger bir nesne ise vejeteryanlar ve ya olmayanlar için hamburger üretme sürecidir.
{
    class Program
    {
        static void Main(string[] args)
        {
            //8
            ProductDirector director = new ProductDirector();
            //var builder = new NewCustomerProductBuilder();
            var builder = new OldCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.ID);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.ReadLine();
            //
        }
    }
    //1
    class ProductViewModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }

    }
    //

    //2.
     abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        //5.
        public abstract ProductViewModel GetModel();
        //
    }
    //

    //3.
    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.ID = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice*(decimal)0.90;
            model.DiscountApplied = true;
        }

        //6
        public override ProductViewModel GetModel()
        {
            return model;
        }
        //
    }
    //

    //4
    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.ID = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        //6
        public override ProductViewModel GetModel()
        {
            return model;
        }
        //
    }
    //

    //7
     class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
    //
}

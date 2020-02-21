using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectDemo
{
    class Program 
        //Nesnelerin bağımsızlığı 
    {
        static void Main(string[] args)
        {
            //3
            //ProductManager productManager = new ProductManager();
            //productManager.Save();
            //Console.ReadLine();
            //

            //7
            ProductManager productManager = new ProductManager(new EfProductDal()); 
            //Bir MVC projesinde bu new'leme yapılmayacak
            ProductManager productManager2 = new ProductManager(new NhProductDal());
            productManager.Save();
            productManager2.Save();

            Console.ReadLine();
            //
            
        }
    }
    //4
    interface IProductDal
    {
        void Save();
    }
    //

    //1
    class EfProductDal:IProductDal //Veri erişim katmanı
    {
        public void Save()
        {
            Console.WriteLine("Saved with EntityFramework");
        }
    }
    //

    //6
    class NhProductDal : IProductDal //Veri erişim katmanı
    {
        public void Save()
        {
            Console.WriteLine("Saved with NHiberNate");
        }
    }
    //


    //2
    class ProductManager
    {
        //5
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        //
        public void Save()
        {

            //Business Code
            //ProductDal productDal = new ProductDal();  //yapılmamalı
            //productDal.Save();
            _productDal.Save();
        }
    }
    //
}

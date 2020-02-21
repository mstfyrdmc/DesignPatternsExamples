using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_IoC_Container
{
    class Program
    {
        //managenugget=> ninject IoC Container indir
        static void Main(string[] args)
        {
            //7
            //kernel'ı ninjectten türettik.
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();
            Console.ReadLine();

            //
        }
        //4
        interface IProductDal
        {
            void Save();
        }
        //

        //1
        class EfProductDal : IProductDal //Veri erişim katmanı
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
}

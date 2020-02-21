using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesingDemo
{
    class Program
    {
        //Elimizde temel bir nesne mevcut iken bu nesneyi farklı koşullarda daha farklı anlamlar yüklemek adına kullanmak için kullanılan bir desing patterndir.
        //örnek : bazı müşterilere özel indirim uygulamak istiyoruz, ve ya bazı özellikleri bazı kullanıcılara uygulamak istiyoruz.
        static void Main(string[] args)
        {
            //4
            var personalCar = new PersonalCar {Make="BMW" , Model="3.20" , HirePrice=2500 };
            //

           

            //7
            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            //9
            specialOffer.DiscountPercentage = 10;
            //
            Console.WriteLine("Concrate:{0}", personalCar.HirePrice);
            Console.WriteLine("Special Offer:{0}", specialOffer.HirePrice);
            Console.ReadLine();
            //
            
        }
        //1
        abstract class CarBase //özelliklerini değiştireceğimiz için abstract yaptık
        {
            public abstract string Make { get; set; } //ezmek için abstract yaptık
            public abstract string Model { get; set; }
            public abstract decimal HirePrice { get; set; }

        }
        //

        //2
        class PersonalCar : CarBase
        {
            public override string Make { get ; set ; }
            public override string Model { get; set; }
            public override decimal HirePrice { get; set; }
        }
        //

        //3
        class CommercialCar : CarBase
        {
            public override string Make { get; set; }
            public override string Model { get; set; }
            public override decimal HirePrice { get; set; }
        }
        //

        //5
       abstract class CarDecoratorBase: CarBase
        {
            private CarBase _carBase;

            protected CarDecoratorBase(CarBase carBase)
            {
                _carBase = carBase;
            }
        }
        //

        //6
        class SpecialOffer : CarDecoratorBase
        {
            //8
            public int DiscountPercentage { get; set; }
            //
            private readonly CarBase _carBase;
            public SpecialOffer(CarBase carBase) : base(carBase)
            {
                _carBase = carBase;
            }
            public override string Make { get; set; }
            public override string Model { get; set ; }
            public override decimal HirePrice
            {
                get
                {
                    return _carBase.HirePrice - _carBase.HirePrice * DiscountPercentage/100;
                }
                set
                {

                }

            }
        }
        //
    }
}

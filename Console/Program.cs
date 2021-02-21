using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
             CarTest();
            // BrandTest();
            // ColorTest();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine(" Color Id \tColor Name  ");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + "\t\t" + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine(" Brand Id \tBrand Name  ");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + "\t\t" + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine(" Car Id \tBrand Name \tColor Name \tDaily Price  ");

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarId + "\t\t" + car.BrandName + "\t\t" + car.ColorName + "\t\t" + car.DailyPrice);

            }
        }
    }
}

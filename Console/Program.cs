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
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
               Console.WriteLine("***NEW CAR***");

               Console.WriteLine("ID:" + car.Id);
               Console.WriteLine("BRANDE ID:" + car.BrandId);
               Console.WriteLine("DESCRIPTION:" + car.Description);
               Console.WriteLine("COLOR ID:" + car.ColorId);
               Console.WriteLine("MODEL YEAR:" + car.ModelYear);
               Console.WriteLine("DAILY PRICE:" + car.DailyPrice);

   
     
            }
            
            
            
        }
    }
}

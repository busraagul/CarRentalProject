using Business.Concrete;
using Business.Constans;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            // BrandTest();
            //ColorTest();
            //UserAddition();
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            
            
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(" CarId \tCarBrand  \tCarDailyPrice \tDescriptions ");
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine(rental.CarId + "\t\t" +rental.CarBrand + "\t\t" +rental.CarDailyPrice + "\t\t" +rental.Descriptions );  

            }

            Console.WriteLine("------------------");
            Console.WriteLine("Kiralama işlemi için aşağıdaki bilgileri doldurunuz");
            Console.WriteLine("Car Id: ");
            int addCarId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer Id: ");
            int addCustomerId = Convert.ToInt32(Console.ReadLine());

            Rental addRental = new Rental
            {
                CarId = addCarId,
                CustomerId = addCustomerId,
                RentDate = DateTime.Now,
                ReturnDate = null
            };
            Console.WriteLine(Messages.SuccessRental);
            


        }

        private static void UserAddition()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            Console.WriteLine("Yeni Kullanıcı Kaydı için Aşağıdaki Alanları Eksiksiz Doldurunuz");
            Console.WriteLine("Adınız:");
            string addFirstName = Console.ReadLine();
            Console.WriteLine("Soyadınız:");
            string addLastName = Console.ReadLine();
            Console.WriteLine("EMail:");
            string addEMail = Console.ReadLine();
            Console.WriteLine("Password: ");
            string addUserPassword = Console.ReadLine();

            User addUserNames = new User
            {
                FirstName = addFirstName,
                LastName = addLastName,
                EMail = addEMail,
                Password = addUserPassword

            };
            userManager.Add(addUserNames);
            Console.WriteLine(Messages.Added);
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


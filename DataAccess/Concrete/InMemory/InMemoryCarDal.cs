using DataAccess.Abstract;
using Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1,BrandId=5,ColorId=88,ModelYear=2021,DailyPrice=1000,Description="BMW" },
                new Car {Id=2,BrandId=3,ColorId=9,ModelYear=2020,DailyPrice=1500,Description="FORD" },
                new Car {Id=3,BrandId=1,ColorId=5,ModelYear=2020,DailyPrice=950,Description="PEUGEOT" },
                new Car {Id=4,BrandId=5,ColorId=3,ModelYear=2013,DailyPrice=500,Description="BMW" },
                new Car {Id=5,BrandId=2,ColorId=7,ModelYear=1990,DailyPrice=50,Description="TOFAŞ" },
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(car);
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == c.Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate= _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
           
               
        }
    }
}

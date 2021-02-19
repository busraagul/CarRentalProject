using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concerete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car {CarId=1,BrandId=5,ColorId=88,ModelYear=2021,DailyPrice=1000,Descriptions="BMW" },
                new Car {CarId=2,BrandId=3,ColorId=9,ModelYear=2020,DailyPrice=1500,Descriptions="FORD" },
                new Car {CarId=3,BrandId=1,ColorId=5,ModelYear=2020,DailyPrice=950,Descriptions="PEUGEOT" },
                new Car {CarId=4,BrandId=5,ColorId=3,ModelYear=2013,DailyPrice=500,Descriptions="BMW" },
                new Car {CarId=5,BrandId=2,ColorId=7,ModelYear=1990,DailyPrice=50,Descriptions="TOFAŞ" },
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           Car carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(car);
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == c.CarId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate= _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
           
               
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        
    }
}

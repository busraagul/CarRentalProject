using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concerete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal  _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.Added);
                
            }
            else
            {
                return new ErrorResult(Messages.DailyPriceInvalid);
                
            }
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
           
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour==00)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            
            return new DataResult<List<Car>>(_carDal.GetAll(),true,Messages.Listed);

        }

        public IDataResult<Car> GetByCarId(int carId)
        {
            return new DataResult<Car>(_carDal.Get(c=>c.CarId == carId),true,Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),true,Messages.Listed);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p=>p.BrandId== id),true,Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id),true);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
                
          
        }
    }
}

using Core.Utilities.Results;
using Entities.Concerete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
       IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        List<Car> GetAll();
        List<Car> GetCarsByColorId(int id);
        List<Car> GetCarsByBrandId(int id);
        List<CarDetailDto> GetCarDetails();
        Car GetByCarId(int carId);
    }
}

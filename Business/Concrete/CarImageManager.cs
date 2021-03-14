using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;
        FileHelper _fileHelper;
        string imagePath = @"..\WebAPI\Images\";
        string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };

        public CarImageManager(ICarImageDal carImageDal, ICarService carService,FileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _carService = carService;
            _fileHelper = fileHelper;
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add( CarImage carImage)
        {
           
            IResult result = BusinessRules.Run(CheckIfCarExists(carImage.CarId));
   
            carImage.Date = DateTime.Now;

            if (result == null)
            {
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.Added);
            }
            return result;

        }
        public IResult Delete(int carImageId, string path)
        {

            var deletePath = _carImageDal.Get(ci => ci.Id == carImageId);

            IResult result = BusinessRules.Run(CheckIfCarImageExists(carImageId));
            if (deletePath != null)
            {
                var resultFileHelper = _fileHelper.Delete(path, deletePath.ImagePath);
                if (resultFileHelper.Success)
                {
                    if (result == null)
                    {
                        _carImageDal.Delete(deletePath);
                        return new SuccessResult(Messages.Deleted);
                    }

                }

            }
            return result;

        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarExists(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            IDataResult<List<CarImage>> resultData = CheckIfCarImageNull(carId);
            if (resultData.Success)
            {
                return resultData;
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId), Messages.Listed);
        }

        //public IResult Update(CarImage carImage)
        //{
            
        //}



        // business rules

        private IResult CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _carImageDal.GetAll(ci => ci.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
        public IDataResult<List<CarImage>> CheckIfCarImageNull(int carId)
        {
            string logoPath = imagePath + "logo.jpg";
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Any();
            if (result == false)
            {
                List<CarImage> imageList = new List<CarImage>();
                imageList.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = logoPath });
                return new SuccessDataResult<List<CarImage>>(imageList);
            }
            return new ErrorDataResult<List<CarImage>>();
        }


        private IResult CheckIfCarExists(int carId)
        {

            var result = _carService.GetByCarId(carId);
            if (result.Data == null)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImageExists(int id)
        {
            var result = _carImageDal.GetAll(ci => ci.Id == id).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CarImageInvalid);
            }
            return new SuccessResult();
        }


    }
}

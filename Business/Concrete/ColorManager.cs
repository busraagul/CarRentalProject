using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

       
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
            
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
           
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new DataResult<List<Color>>(_colorDal.GetAll(),true,Messages.Listed);
            
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
            
        }
    }
}

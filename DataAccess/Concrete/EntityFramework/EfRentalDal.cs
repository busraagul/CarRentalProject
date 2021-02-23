
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {

                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join cstmr in context.Customers on r.CustomerId equals cstmr.CustomerId
                             join u in context.Users on cstmr.UserId equals u.UserId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CustomerId = cstmr.CustomerId,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 CarId = c.CarId,
                                 CarDailyPrice = c.DailyPrice,
                                 CarBrand = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 Descriptions = c.Descriptions
                             };
                return result.ToList();


            }
        }
    }
}

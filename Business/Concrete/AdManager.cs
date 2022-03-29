using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Core6.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdManager : IAdService
    {

        IAdDal _adDal;

        public AdManager(IAdDal adDal)
        {

            
            _adDal = adDal;

        }
        public IResult Add(Ad ad)
        {

          
            _adDal.Add(ad);
            return new SuccessResult();
        }

        public IResult Delete(Ad ad)
        {
           _adDal.Delete(ad);
            return new SuccessResult();
        }

        public IDataResult<Ad> FindByAdId(int adId)
        {
            return new SuccessDataResult<Ad>(_adDal.Get(x=>x.adId==adId));
        }

        public IDataResult<List<AdDetailsDto>> GetAllAdDetails()
        {
            var list = _adDal.getAllAdDetails();
            var newListByDate=list.OrderByDescending(p=>p.createdDate).ToList();
            return new SuccessDataResult<List<AdDetailsDto>>(newListByDate);
        }

        public IDataResult<AdDetailsDto> GetAllAdDetailsByAdId(int adId)
        {
            return new SuccessDataResult<AdDetailsDto>(_adDal.getAllAdDetailsByAdId(adId));
        }

        public IDataResult<List<AdDetailsDto>> getAllAdDetailsByCityAndByRegion(string cityName, string regionName)
        {
            return new SuccessDataResult<List<AdDetailsDto>>(_adDal.getAllAdDetailsByCityAndByRegion(cityName, regionName));
        }

        public IDataResult<List<AdDetailsDto>> GetAllAdDetailsByCityName(string cityName)
        {
            return new SuccessDataResult<List<AdDetailsDto>>(_adDal.getAllAdDetailsByCityName(cityName));
        }

        public IDataResult<List<AdDetailsDto>> GetAllAdDetailsByUserId(int userId)
        {
            var list = _adDal.getAllAdDetailsByUserId(userId);
            var newListByDate = list.OrderByDescending(p => p.createdDate).ToList();

            return new SuccessDataResult<List<AdDetailsDto>>(newListByDate);
        }

        public IDataResult<List<Ad>> getAllAds()
        {
            return new SuccessDataResult<List<Ad>>(_adDal.GetAll());
        }

        public IResult UpDate(Ad ad)
        {
          _adDal.UpDate(ad);
            return new SuccessResult();
        }
    }
}

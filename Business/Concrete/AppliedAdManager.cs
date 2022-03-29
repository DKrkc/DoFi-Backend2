using Business.Abstract;
using Business.Constants;
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
    public class AppliedAdManager : IAppliedAdService
    {

        IAppliedAdDal _appliedDal;
        public AppliedAdManager(IAppliedAdDal appliedDal)
        {
            _appliedDal= appliedDal;
        }
        public IResult Add(AppliedAd appliedAd)
        {
            _appliedDal.Add(appliedAd);
            return new SuccessResult();
        }

        public IResult Delete(AppliedAd appliedAd)
        {
           _appliedDal.Delete(appliedAd);
            return new SuccessResult();
        }

        public IDataResult<AppliedAd> FindById(int id)
        {

            return new SuccessDataResult<AppliedAd>(_appliedDal.Get(x => x.id==id));
        }

        public IDataResult<List<AppliedAd>> FindTheListOfAppliedJobsByAdId(int adId)
        {
         
            return new SuccessDataResult<List<AppliedAd>>(_appliedDal.GetAll(x => x.adId == adId));
        }

        public IDataResult<List<AppliedAdDetailsDto>> getAll()
        {
            return new SuccessDataResult<List<AppliedAdDetailsDto>>(_appliedDal.GetAll());
        }

        public IDataResult<List<AppliedAdDetailsDto>> getAllDetailsWhoApplied(int adId)
        {
            var people = _appliedDal.GetAppliedAdDetailsByAdId(adId);
            if (people.Count >0)
            {
                return new SuccessDataResult<List<AppliedAdDetailsDto>>(people);
            }
            return new ErrorDataResult<List<AppliedAdDetailsDto>>(Messages.NotFoundPeopleWhoApplied);
        }

        public IDataResult<List<AdDetailsDto>> GetAppliedAdDetailsByUserId(int userId)
        {
           var ads=_appliedDal.GetAppliedAdDetailsByUserId(userId);
            if (ads.Count > 0)
            {
                var newList=ads.OrderByDescending(x=>x.createdDate).ToList();   
                return new SuccessDataResult<List<AdDetailsDto>>(newList);
            }
            return new ErrorDataResult<List<AdDetailsDto>>(Messages.NotFoundJobsWhoYouApplied);
        }
    }
}

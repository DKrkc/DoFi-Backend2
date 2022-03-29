using Core6.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAppliedAdDal : EfEntityRepositoryBase<AppliedAd, DogWalkerContext>, IAppliedAdDal
    {

        public List<AppliedAdDetailsDto> GetAll()
        {
            using (DogWalkerContext context = new DogWalkerContext())
            {
                var result = from a in context.AppliedAds
                             join e in context.Users
                             on a.jobSeekerId equals e.userId

                           

                             select new AppliedAdDetailsDto
                             {
                                 userId=e.userId,
                                 whoAppliedname = e.firstName + " " + e.lastName,
                             };
                return result.ToList();
            }
        }
        public List<AppliedAdDetailsDto> GetAppliedAdDetailsByAdId(int adId)
        {
            using (DogWalkerContext context = new DogWalkerContext())
            {
                var result = from a in context.AppliedAds
                             join e in context.Users
                             on a.jobSeekerId equals e.userId

                             where a.adId == adId

                             select new AppliedAdDetailsDto
                             {
                                 userId = e.userId,
                                 whoAppliedname =e.firstName+" "+e.lastName,
                             };
                return result.ToList();
            }
        }

        public List<AdDetailsDto> GetAppliedAdDetailsByUserId(int userId)
        {
            using (DogWalkerContext context = new DogWalkerContext())
            {
                var result = from a in context.AppliedAds
                             join e in context.Ads
                             on a.adId equals e.adId

                             join c in context.Cities
                            on e.cityId equals c.cityId

                             join r in context.Regions
                             on e.regionId equals r.regionId

                             join u in context.Users
                             on e.employerId equals u.userId


                             where a.jobSeekerId==userId

                             select new AdDetailsDto
                             {
                                 adId = a.adId,
                                 employerName = u.firstName + " " + u.lastName,
                                 location = c.cityName + "," + r.regionName,
                                 description = e.description,
                                 createdDate = e.createdDate,
                                 deadlineDate = e.deadlineDate,
                             };
                return result.ToList();
            }
        }
    }
}

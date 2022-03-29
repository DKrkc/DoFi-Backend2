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
    public class EfAdDal : EfEntityRepositoryBase<Ad, DogWalkerContext>, IAdDal
    {
        public List<AdDetailsDto> getAllAdDetails()
        {
            using (DogWalkerContext context = new DogWalkerContext())
            {
                var result = from ad in context.Ads
                             join e in context.Users
                             on ad.employerId equals e.userId

                             join c in context.Cities
                             on ad.cityId equals c.cityId

                             join r in context.Regions
                             on ad.regionId equals r.regionId




                             select new AdDetailsDto
                             {
                                 adId = ad.adId,
                                 userId = e.userId,
                                 employerName = e.firstName + " " + e.lastName,
                                 location = c.cityName + "," + r.regionName,
                                 description = ad.description,
                                 createdDate = ad.createdDate,
                                 deadlineDate = ad.deadlineDate,
                             };
                return result.ToList();

            }
        }

        public AdDetailsDto getAllAdDetailsByAdId(int adId)
        {
            using (DogWalkerContext context = new DogWalkerContext())
            {
                var result = from ad in context.Ads
                             join e in context.Users
                             on ad.employerId equals e.userId

                             join c in context.Cities
                             on ad.cityId equals c.cityId

                             join r in context.Regions
                             on ad.regionId equals r.regionId

                             where ad.adId==adId


                             select new AdDetailsDto
                             {
                                 adId = ad.adId,
                                 userId = e.userId,
                                 employerName = e.firstName + " " + e.lastName,
                                 location = c.cityName + "," + r.regionName,
                                 description = ad.description,
                                 createdDate = ad.createdDate,
                                 deadlineDate = ad.deadlineDate,
                             };
                return result.SingleOrDefault(); 

            }
        }
    

        public List<AdDetailsDto> getAllAdDetailsByCityAndByRegion(string cityName, string regionName)
        {
            using (DogWalkerContext context = new DogWalkerContext())
            {
                var result = from ad in context.Ads
                             join e in context.Users
                             on ad.employerId equals e.userId

                             join c in context.Cities
                             on ad.cityId equals c.cityId

                             join r in context.Regions
                             on ad.regionId equals r.regionId

                             where c.cityName == cityName
                             where r.regionName == regionName


                             select new AdDetailsDto
                             {
                                 adId = ad.adId,
                                 userId = e.userId,
                                 employerName = e.firstName + " " + e.lastName,
                                 location = c.cityName + "," + r.regionName,
                                 description = ad.description,
                                 createdDate = ad.createdDate,
                                 deadlineDate = ad.deadlineDate,
                             };
                return result.ToList();

            }

        }

        public List<AdDetailsDto> getAllAdDetailsByCityName(string cityName)
        {

            using (DogWalkerContext context = new DogWalkerContext())
            {
                var result = from ad in context.Ads
                             join e in context.Users
                             on ad.employerId equals e.userId

                             join c in context.Cities
                             on ad.cityId equals c.cityId

                             join r in context.Regions
                             on ad.regionId equals r.regionId

                             where c.cityName == cityName


                             select new AdDetailsDto
                             {
                                 adId = ad.adId,
                                 userId = e.userId,
                                 employerName = e.firstName + " " + e.lastName,
                                 location = c.cityName + "," + r.regionName,
                                 description = ad.description,
                                 createdDate = ad.createdDate,
                                 deadlineDate = ad.deadlineDate,
                             };
                return result.ToList();

            }
        }

        public List<AdDetailsDto> getAllAdDetailsByUserId(int userId)
        {
            using (DogWalkerContext context = new DogWalkerContext())
            {
                var result = from ad in context.Ads
                             join e in context.Users
                             on ad.employerId equals e.userId

                             join c in context.Cities
                             on ad.cityId equals c.cityId

                             join r in context.Regions
                             on ad.regionId equals r.regionId

                             where ad.employerId == userId


                             select new AdDetailsDto
                             {
                                 adId = ad.adId,
                                 userId = e.userId,
                                 employerName = e.firstName + " " + e.lastName,
                                 location = c.cityName + "," + r.regionName,
                                 description = ad.description,
                                 createdDate = ad.createdDate,
                                 deadlineDate = ad.deadlineDate,
                             };
                return result.ToList();

            }
        }
    }
}

using Core6.Results;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdService
    {

        IResult Add(Ad ad);
        IResult UpDate(Ad ad);
        IResult Delete(Ad ad);
        IDataResult<Ad> FindByAdId(int adId);
        IDataResult<List<Ad>> getAllAds();

        IDataResult<List<AdDetailsDto>> GetAllAdDetails();
        IDataResult<List<AdDetailsDto>> GetAllAdDetailsByUserId(int userId);
        IDataResult<AdDetailsDto> GetAllAdDetailsByAdId(int adId);

        IDataResult<List<AdDetailsDto>> GetAllAdDetailsByCityName(string cityName);

        IDataResult<List<AdDetailsDto>> getAllAdDetailsByCityAndByRegion(string cityName, string regionName);
    }
}

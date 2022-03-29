using Core6.DataAccess;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IAdDal: IEntityRepository<Ad>
    {

        List<AdDetailsDto> getAllAdDetails();

        List<AdDetailsDto> getAllAdDetailsByUserId(int userId);
        AdDetailsDto getAllAdDetailsByAdId(int userId);

        List<AdDetailsDto> getAllAdDetailsByCityName(string cityName);

        List<AdDetailsDto> getAllAdDetailsByCityAndByRegion(string cityName,string regionName);

       
    }

}

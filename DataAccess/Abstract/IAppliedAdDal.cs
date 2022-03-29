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
   public interface IAppliedAdDal: IEntityRepository<AppliedAd>
    {
        List<AppliedAdDetailsDto> GetAll();
        List<AppliedAdDetailsDto> GetAppliedAdDetailsByAdId(int adId);
        List<AdDetailsDto> GetAppliedAdDetailsByUserId(int userId);
    }
}

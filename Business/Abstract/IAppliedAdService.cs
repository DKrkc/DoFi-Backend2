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
    public interface IAppliedAdService
    {
        IDataResult<List<AppliedAdDetailsDto>> getAll();
        IDataResult<List<AppliedAdDetailsDto>> getAllDetailsWhoApplied(int adId);
        IDataResult<List<AdDetailsDto>> GetAppliedAdDetailsByUserId(int userId);
        IDataResult<AppliedAd> FindById(int id);
        IDataResult<List<AppliedAd>> FindTheListOfAppliedJobsByAdId(int adId);
       IResult Add(AppliedAd appliedAd);
        IResult Delete(AppliedAd appliedAd);
    }
}

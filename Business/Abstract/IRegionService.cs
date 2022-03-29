
using Core6.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRegionService
    {
        IResult Add(Region region);
        IResult Update(Region region);
        IDataResult<List<Region>> FindByCityId(int cityId);
        IDataResult<Region> FindById(int id);
        IDataResult<List<Region>> GetAll();
      IResult Delete(Region region);
    }
}

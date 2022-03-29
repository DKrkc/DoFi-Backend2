
using Core6.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILocationService
    {
      
        IResult Add(Location location);
        IResult Update(Location location);
       // IDataResult<Location> FindByUserId(int userId);
        IResult Delete(Location location);
        IDataResult<Location> FindById(int locationId);
    }
}

using Business.Abstract;


using Core6.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public  class LocationManager:ILocationService
    {

        ILocationDal _locationDal;

        public LocationManager(ILocationDal locationService)
        {
            _locationDal = locationService;
        }

        public IResult Add(Location location)
        {
            _locationDal.Add(location);
            return new SuccessResult();
        }

        public IResult Delete(Location location)
        {
            _locationDal.Delete(location);
            return new SuccessResult();
        }

        public IDataResult<Location> FindById(int locationId)
        {
            return new SuccessDataResult<Location>(_locationDal.Get(x => x.locationId == locationId));
        }

       

        public IResult Update(Location location)
        {
            _locationDal.UpDate(location);
            return new SuccessResult();
        }
    }
}

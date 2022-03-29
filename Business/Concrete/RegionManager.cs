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
    public class RegionManager:IRegionService
    {
        IRegionDal _regionDal;

        public RegionManager(IRegionDal regionDal)
        {
            _regionDal = regionDal;
        }

        public IResult Add(Region region)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Region region)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Region>> FindByCityId(int cityId)
        {
            return new SuccessDataResult<List<Region>>(_regionDal.GetAll(x => x.cityId == cityId));
        }

        public IDataResult<Region> FindById(int id)
        {
            return new SuccessDataResult<Region>(_regionDal.Get(x => x.regionId == id));


        }

        public IDataResult<List<Region>> GetAll()
        {
            return new SuccessDataResult<List<Region>>(_regionDal.GetAll());
        }

        public IResult Update(Region region)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class EmployerManager : IEmployerService
    {

        IEmployerDal _employerDal;

        public EmployerManager(IEmployerDal employerDal)
        {
            _employerDal= employerDal;
        }
        public IResult AddUser(Employer employer)
        {
          _employerDal.Add(employer);
            return new SuccessResult();
        }

        public IResult DeleteUser(Employer employer)
        {
            _employerDal.Delete(employer);
            return new SuccessResult();
        }

        public IDataResult<Employer> FindById(int userId)
        {
           return new SuccessDataResult<Employer>(_employerDal.Get(x=>x.userId == userId));
        }

        public IDataResult<List<Employer>> GetAll()
        {
            return new SuccessDataResult<List<Employer>>(_employerDal.GetAll());
        }

        public IResult UpdateUser(Employer employer)
        {
            _employerDal.UpDate(employer);
            return new SuccessResult();
        }
    }
}

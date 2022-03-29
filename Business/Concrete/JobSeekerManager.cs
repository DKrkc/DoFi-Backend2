using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core6.Results;
using Core6.Utilities.Aspects.Autofac.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class JobSeekerManager :  IJobSeekerService
    {

        IJobSeekerDal _jobSeekerDal;
        public JobSeekerManager(IJobSeekerDal jobSeekerDal)
        {
            _jobSeekerDal=jobSeekerDal;

        }

       
        

        public IResult AddUser(JobSeeker jobSeeker)
        {
            _jobSeekerDal.Add(jobSeeker);
            return new SuccessResult("Eklendi.");
        }

        public IResult DeleteUser(JobSeeker jobSeeker)
        {

            _jobSeekerDal.Delete(jobSeeker);
            return new SuccessResult("Silindi");
        }

        public IDataResult<JobSeeker> FindById(int userId)
        {
           
            return new SuccessDataResult<JobSeeker>(_jobSeekerDal.Get(x=>x.userId==userId));
        }

        public IDataResult<List<JobSeeker>> GetAll()
        {
           return new SuccessDataResult<List<JobSeeker>>(_jobSeekerDal.GetAll());
        }

        public IResult UpdateUser(JobSeeker jobSeeker)
        {
            _jobSeekerDal.UpDate(jobSeeker);
            return new SuccessResult();
        }
    }
}

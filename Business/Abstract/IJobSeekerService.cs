
using Core6.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobSeekerService
    {
        IDataResult<List<JobSeeker>> GetAll();
        IResult AddUser(JobSeeker jobSeeker);
        IResult UpdateUser(JobSeeker jobSeeker);
        IDataResult<JobSeeker> FindById(int userId);
        IResult DeleteUser(JobSeeker jobSeeker);

    }
}

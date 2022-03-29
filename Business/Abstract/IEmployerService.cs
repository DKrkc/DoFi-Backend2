
using Core6.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployerService
    {
        IDataResult<List<Employer>> GetAll();
        IResult AddUser(Employer employer);
        IResult UpdateUser(Employer employer);
        IDataResult<Employer> FindById(int userId);
        IResult DeleteUser(Employer employer);
    }
}

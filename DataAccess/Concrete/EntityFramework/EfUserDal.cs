using Core6.DataAccess.EntityFramework;
using Core6.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DogWalkerContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DogWalkerContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.id equals userOperationClaim.operationClaimId
                             where userOperationClaim.userId == user.userId
                             select new OperationClaim { id = operationClaim.id, name = operationClaim.name };
                return result.ToList();

            }
        }
    }
}

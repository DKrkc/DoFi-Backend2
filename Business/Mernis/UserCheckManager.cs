using Core6.Entities.Concrete;
using Core6.Results;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mernis
{
    public class UserCheckManager : IUserCheckService
    {
        public bool CheckIfRealPerson(UserRegisterDto user)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
          var response= client.TCKimlikNoDogrulaAsync(Convert.ToInt64(user.nationalityId),
               user.firstName.ToUpper(), user.lastName.ToUpper(), user.birthOfDate.Year);
            var result=response.Result;

            return result.Body.TCKimlikNoDogrulaResult;
        }
    }
}

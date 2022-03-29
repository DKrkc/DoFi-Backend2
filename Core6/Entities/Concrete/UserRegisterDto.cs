using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core6.Entities.Concrete
{
    public class UserRegisterDto:IDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nationalityId { get; set; }
        public DateTime birthOfDate { get; set; }

        [DataType(DataType.EmailAddress)]
        public string mail { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
       // public string role = "user";

       
       


    }
}

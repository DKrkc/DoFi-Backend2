using Core6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Ad:IEntity
    {

        public int adId { get; set; }
        public int employerId { get; set; }
        public string description { get; set; }
        public int cityId { get; set; }
        public int regionId { get; set; }


        public DateTime createdDate { get;set; }
        public DateTime deadlineDate { get; set; }


    

    }
}

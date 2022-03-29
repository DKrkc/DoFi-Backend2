using Core6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
   public  class AdDetailsDto:IDto
    {

        public int adId { get; set; }
        public int userId { get; set; }
      
        public string employerName { get; set; }
        public string location { get; set; }
        public string description { get; set; }

        public DateTime createdDate { get; set; }
        public DateTime deadlineDate { get; set; }
    }
}

using Core6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class CommentDetailsDto:IDto
    {

        public int id { get; set; } 
        public bool isReported { get; set; }
        public int whopostedId { get;set; }
        public string username { get; set; }
        public string commentText { get; set; }

        public DateTime date { get; set; }

      
    }
}

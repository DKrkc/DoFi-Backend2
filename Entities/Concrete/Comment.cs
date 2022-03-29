using Core6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int commentId { get; set; }
        public int whopostedId { get; set; }
        public int whotakenId { get; set; }
        public string commentText { get; set; }
        public bool isReported { get; set; }
        public DateTime date { get; set; }




    }
}

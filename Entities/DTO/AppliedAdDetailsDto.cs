using Core6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class AppliedAdDetailsDto:IDto
    {
        public int userId { get; set; }
        public string whoAppliedname { get; set; }

    }
}

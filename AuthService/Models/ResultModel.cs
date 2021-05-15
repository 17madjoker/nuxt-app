using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Models
{
    public class ResultModel
    {
        public bool IsSuccess { get; set; }

        public IEnumerable<string> Messages { get; set; }
    }
}

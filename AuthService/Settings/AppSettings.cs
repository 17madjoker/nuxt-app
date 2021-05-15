using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Settings
{
    public class AppSettings
    {
        public Connections ConnectionStrings { get; set; }

        public CorsSettings Cors { get; set; }
    }
}

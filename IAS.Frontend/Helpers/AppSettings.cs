using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAS.Frontend.Helpers
{
    public class AppSettings
    {
        public string Expiration { get; set; }
        public string SECRET { get; set; }
        public string ISTEST { get; set; }
        public string SQL_USERID { get; set; }
        public string SQL_PASSWD { get; set; }
    }
}

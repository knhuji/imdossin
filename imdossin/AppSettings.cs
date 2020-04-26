using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imdossin
{
    public class AppSettings
    {
        public string MovieUrl { get; set; }
        public string IdentityUrl { get; set; }
        public ClientCredentials ClientCredentials { get; set; }
    }

    public class ClientCredentials
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
    }
}

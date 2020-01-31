using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Utils.jwt
{
    public class JWTConfig
    {
        public string SigningKey { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssuerSigningKey { set; get; }

        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }

        public long ExpireMinutes { set; get; }
    }
}

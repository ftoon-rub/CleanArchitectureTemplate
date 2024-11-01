using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Configurations
{
    public class AppSettingsConfig : IAppSettingsConfig
    {
        public CustomAuthenticate CustomAuthenticate { get; set; }
    }

    public class CustomAuthenticate
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public JwtBearer JwtBearer { get; set; }
    }
    public class JwtBearer
    {
        public int JwtTimeOutInHours { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
    }
}

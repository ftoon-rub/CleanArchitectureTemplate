using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.InfrastructureLayer
{
    public interface IJwtTokenGeneration
    {
        TokenModel GenerateJwtToken(IDictionary<string, string>? additionalClaims = null);
        TokenModel GenerateJwtToken(Guid UserId, IDictionary<string, string>? additionalClaims = null);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Enums
{
    public enum ErrorCode
    {
        Success = 0,
        NotFound,
        InvalidInput,
        Unauthorized,
        InternalError,
        Timeout 
    }
}

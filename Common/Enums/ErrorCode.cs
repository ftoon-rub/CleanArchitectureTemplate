using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
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

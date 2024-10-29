using Common.Enums;
using Common.Models.BaseModels;

namespace Common.Exceptions.BaseException
{
    public class BaseCustomException : Exception
    {
        public ErrorDetails ErrorDetails { get; set; }

        public BaseCustomException(ErrorDetails errorDetails) : base()
        {
            ErrorDetails = errorDetails;
        }

        public BaseCustomException(string methodName, ErrorCode errorCode, string errorDescription) : base()
        {
            ErrorDetails = new();
            ErrorDetails.IsSuccess = false;
            ErrorDetails.ErrorCode = errorCode;
            ErrorDetails.ErrorTitle = errorCode.ToString();
            ErrorDetails.ErrorDescription = "Error on method:" + methodName + "\t" + errorDescription;

        }
    }
}

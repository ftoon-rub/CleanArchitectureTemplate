using ApplicationLayer.Enums;

namespace ApplicationLayer.Models.BaseModels
{
    public class ErrorDetails
    {
        public ErrorDetails()
        {
            IsSuccess = true;
            Timestamp = DateTime.Now;
        }
        public ErrorDetails(bool isSuccess, ErrorCode errorCode, string errorDescription)
        {
            IsSuccess = isSuccess;
            ErrorCode = errorCode;
            ErrorTitle = errorCode.ToString();
            ErrorDescription = errorDescription;
            Timestamp = DateTime.Now;
        }

        public bool IsSuccess { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public string ErrorTitle { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

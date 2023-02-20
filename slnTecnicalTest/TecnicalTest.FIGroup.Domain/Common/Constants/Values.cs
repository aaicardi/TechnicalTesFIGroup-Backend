namespace TecnicalTest.FIGroup.Domain.Common.Constants;

public static class Values
{
    #region Values
    public const int CodeExpiryMinutes = 5;
    public const int FileExpiryMinutes = 5;
    public const int DefaultPage = 1;
    public const int DefaultLimit = 10;
    public const int MaximumHoursToEditAppointment = 48;
    #endregion

    #region Texts

    public const string UsaPhoneCode = "+1 ";
    public const string Errors = "errors";
    public const string SuccessMessages = "successfull operation";
    public const string ValidationErrorMessage = "One or more validation failures have occurred.";
    public const string ValidationErrorTitle = "Entity.ValidationProblems";
    public const string ValidationErrorType = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1";
    public const string UnknownExceptionErrorTitle = "Server.UnexpectedError";
    public const string UnknownExceptionErrorType = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
    public const string UnknownExceptionErrorDetail = "An error occurred while processing your request.";
    #endregion
}

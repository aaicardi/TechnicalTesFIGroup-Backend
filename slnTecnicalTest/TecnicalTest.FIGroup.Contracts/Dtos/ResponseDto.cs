using System.Net;

namespace TecnicalTest.FIGroup.Contracts.Dtos;

public record ResponseDto
{
    public ResponseDto(string message)
    {
        IsSuccess = true;
        Message = message;
        StatusCode = HttpStatusCode.OK;
    }
    public ResponseDto(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        IsSuccess = false;
        Message = message;
        StatusCode = statusCode;
    }

    public bool IsSuccess { get; set; } = true;
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}



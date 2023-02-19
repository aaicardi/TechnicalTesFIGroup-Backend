using System.Net;

namespace TecnicalTest.FIGroup.Contracts.Dtos;

public record GenericResponseDto<T> where T : class?
{
    public GenericResponseDto(string message, HttpStatusCode statusCode)
    {
        IsSuccess = false;
        Message = message;
        StatusCode = statusCode;
        Data = default;
    }

    public GenericResponseDto(T data)
    {
        Message = "OK";
        Data = data;
        StatusCode = HttpStatusCode.OK;
    }
    public GenericResponseDto(T data, int page, int perPage, int pageCount, int totalCount)
    {
        Message = "OK";
        Metadata = new ListInformationResponseDto(page, perPage, pageCount, totalCount);
        Data = data;
        StatusCode = HttpStatusCode.OK;
    }
    public bool IsSuccess { get; set; } = true;
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public ListInformationResponseDto? Metadata { get; set; }
    public T? Data { get; set; }
}

public record ListInformationResponseDto(int Page, int PerPage, int PageCount, int TotalCount);


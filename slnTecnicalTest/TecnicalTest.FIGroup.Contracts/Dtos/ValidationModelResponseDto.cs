namespace TecnicalTest.FIGroup.Contracts.Dtos;

public record ValidationModelResponseDto
(
    string Type,
    string Title,
    int Status,
    string Detail,
    string TraceId,
    List<ValidationErrors> Errors
);

namespace TecnicalTest.FIGroup.Contracts.Dtos;

public record ValidationErrors
{
    public string Key { get; init; } = null!;
    public string[]? Problems { get; init; }
}


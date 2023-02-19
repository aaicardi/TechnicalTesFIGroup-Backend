using FluentValidation.Results;

namespace TecnicalTest.FIGroup.Domain.Common.Exceptions;

public sealed class ValidationAppException : Exception
{
    private ValidationAppException() : base("One or more validation errors occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationAppException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureArray => failureArray.Key, failureArray => failureArray.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }

}


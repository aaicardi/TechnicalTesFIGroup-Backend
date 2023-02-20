using FluentValidation;

namespace TecnicalTest.FIGroup.Application.Services.Tasks.Handlers.UpdateTask;

public sealed class UpdateTasksCommandValidator : AbstractValidator<UpdateTasksCommand>
{
    public UpdateTasksCommandValidator()
    {
        RuleFor(c => c.TasksDto.Description).NotNull().NotEmpty();
    }
}


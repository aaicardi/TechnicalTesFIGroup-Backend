using FluentValidation;

namespace TecnicalTest.FIGroup.Application.Services.Tasks.Handlers.CreateTasks;

public sealed class CreateTasksCommandValidator : AbstractValidator<CreateTasksCommand>
{
    public CreateTasksCommandValidator()
    {
        RuleFor(c => c.TasksDto.Description).NotNull().NotEmpty();             
    }
}


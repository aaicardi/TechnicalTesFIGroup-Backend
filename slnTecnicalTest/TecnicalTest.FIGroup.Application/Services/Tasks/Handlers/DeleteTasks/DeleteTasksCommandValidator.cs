using FluentValidation;

namespace TecnicalTest.FIGroup.Application.Services.Tasks.Handlers.DeleteTasks;

public sealed class DeleteTasksCommandValidator : AbstractValidator<DeleteTasksCommand>
{
    public DeleteTasksCommandValidator()
    {
        RuleFor(c => c.TasksId).NotEqual(0).NotNull();
    }
}


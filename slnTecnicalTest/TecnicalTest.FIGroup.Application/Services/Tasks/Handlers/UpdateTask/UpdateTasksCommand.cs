using ErrorOr;
using MediatR;
using TecnicalTest.FIGroup.Contracts.Dtos;

namespace TecnicalTest.FIGroup.Application.Services.Tasks.Handlers.UpdateTask;

public sealed record UpdateTasksCommand(TasksDto TasksDto) : IRequest<ErrorOr<ResponseDto>>;


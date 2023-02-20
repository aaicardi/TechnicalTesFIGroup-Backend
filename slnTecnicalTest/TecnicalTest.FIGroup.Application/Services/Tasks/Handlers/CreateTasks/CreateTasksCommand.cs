using ErrorOr;
using MediatR;
using TecnicalTest.FIGroup.Contracts.Dtos;

namespace TecnicalTest.FIGroup.Application.Services.Tasks.Handlers.CreateTasks;

public sealed record CreateTasksCommand(TasksDto TasksDto) : IRequest<ErrorOr<ResponseDto>>;



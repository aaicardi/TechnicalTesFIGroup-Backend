using ErrorOr;
using MediatR;
using TecnicalTest.FIGroup.Contracts.Dtos;

namespace TecnicalTest.FIGroup.Application.Services.Tasks.Handlers.DeleteTasks;

public sealed record DeleteTasksCommand(int TasksId) : IRequest<ErrorOr<ResponseDto>>;
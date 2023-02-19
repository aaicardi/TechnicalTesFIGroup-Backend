using ErrorOr;

using MediatR;

using TecnicalTest.FIGroup.Contracts.Dtos;

namespace TecnicalTest.FIGroup.Application.Services.Tasks.Queries.GetAllTasks;

public sealed record GetAllTasksQuery : IRequest<ErrorOr<GenericResponseDto<List<TasksDto>>>>;


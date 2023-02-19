using ErrorOr;
using MapsterMapper;
using MediatR;
using TecnicalTest.FIGroup.Contracts.Dtos;
using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;

namespace TecnicalTest.FIGroup.Application.Services.Tasks.Queries.GetAllTasks;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, ErrorOr<GenericResponseDto<List<TasksDto>>>>
{
    private readonly IMapper _mapper;
    private readonly IFacadeRepository _facadeRepository;

    public GetAllTasksQueryHandler(IFacadeRepository facadeRepository, IMapper mapper)
    {
        _facadeRepository = facadeRepository;
        _mapper = mapper;
    }


    public async Task<ErrorOr<GenericResponseDto<List<TasksDto>>>> Handle(GetAllTasksQuery query,
CancellationToken cancellationToken)
    {
        var locales = _facadeRepository.TasksRepository.GetAllTasks();
        return await Task.FromResult(
            new GenericResponseDto<List<TasksDto>>(_mapper.Map<List<TasksDto>>(locales)));
    }
}


using ErrorOr;
using MapsterMapper;
using MediatR;
using TecnicalTest.FIGroup.Contracts.Dtos;
using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;
using TecnicalTest.FIGroup.Application.Common.Errors;

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
        try
        {

            var locales = _facadeRepository.TasksRepository.GetAllTasks();

            if (locales.ToList().Count > 0)
            {
                return await Task.FromResult(
                  new GenericResponseDto<List<TasksDto>>(_mapper.Map<List<TasksDto>>(locales)));
            }else
                return Errors.Tasks.TasksNotFound(string.Empty);
        }
        catch (Exception ex)
        {
            return Errors.Tasks.TasksFailed(ex.Message);
        }


    }
}


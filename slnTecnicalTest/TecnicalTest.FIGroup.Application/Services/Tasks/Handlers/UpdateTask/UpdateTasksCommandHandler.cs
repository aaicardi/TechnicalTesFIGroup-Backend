using ErrorOr;
using MapsterMapper;
using MediatR;
using TecnicalTest.FIGroup.Contracts.Dtos;
using TecnicalTest.FIGroup.Domain.Common.Constants;
using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;
using TecnicalTest.FIGroup.Application.Common.Errors;
namespace TecnicalTest.FIGroup.Application.Services.Tasks.Handlers.UpdateTask;

public class UpdateTasksCommandHandler : IRequestHandler<UpdateTasksCommand, ErrorOr<ResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IFacadeRepository _facadeRepository;

    public UpdateTasksCommandHandler(IMapper mapper, IFacadeRepository facadeRepository) 
    {
        _mapper = mapper;
        _facadeRepository = facadeRepository;
    }

    public async Task<ErrorOr<ResponseDto>> Handle(UpdateTasksCommand request, CancellationToken cancellationToken)
    {

        try
        {
            var resultCreate = await _facadeRepository.TasksRepository.UpdateTasks(_mapper.Map<TecnicalTest.FIGroup.Domain.Entities.Tasks>(request.TasksDto));
            if (resultCreate != null)
                return new ResponseDto(Values.SuccessMessages);
            else
                return Errors.Tasks.TasksNotFound(string.Empty);
        }
        catch (Exception ex)
        {
            return Errors.Tasks.TasksFailed(ex.Message);
        }

    }
}


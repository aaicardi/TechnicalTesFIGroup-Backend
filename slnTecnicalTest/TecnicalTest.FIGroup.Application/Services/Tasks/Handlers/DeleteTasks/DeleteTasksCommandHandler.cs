using ErrorOr;
using MediatR;
using TecnicalTest.FIGroup.Contracts.Dtos;
using TecnicalTest.FIGroup.Domain.Common.Constants;
using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;
using TecnicalTest.FIGroup.Application.Common.Errors;

namespace TecnicalTest.FIGroup.Application.Services.Tasks.Handlers.DeleteTasks;

public class DeleteTasksCommandHandler : IRequestHandler<DeleteTasksCommand, ErrorOr<ResponseDto>>
{
    private readonly IFacadeRepository _facadeRepository;

    public DeleteTasksCommandHandler( IFacadeRepository facadeRepository)
    {
        _facadeRepository = facadeRepository;
    }

    public async Task<ErrorOr<ResponseDto>> Handle(DeleteTasksCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _facadeRepository.TasksRepository.DeleteTasks(request.TasksId);
            if (result.Id != 0)
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


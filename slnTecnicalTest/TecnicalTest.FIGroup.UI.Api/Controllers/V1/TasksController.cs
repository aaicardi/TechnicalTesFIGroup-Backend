using MediatR;
using Microsoft.AspNetCore.Mvc;
using TecnicalTest.FIGroup.Application.Services.Tasks.Queries.GetAllTasks;
using TecnicalTest.FIGroup.Contracts.Dtos;

namespace TecnicalTest.FIGroup.UI.Api.Controllers.V1;


public class TasksController : ApiController
{
    private readonly ISender _sender;

    public TasksController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponseDto<List<TasksDto>>))]
    public async Task<IActionResult> GetLocales()
    {
        var response = await _sender.Send(new GetAllTasksQuery());
        return response.Match(
            Ok,
            Problem
        );
    }
}


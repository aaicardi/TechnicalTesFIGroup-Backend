using MediatR;
using Microsoft.AspNetCore.Mvc;

using TecnicalTest.FIGroup.Application.Services.Tasks.Handlers.CreateTasks;
using TecnicalTest.FIGroup.Application.Services.Tasks.Handlers.DeleteTasks;
using TecnicalTest.FIGroup.Application.Services.Tasks.Handlers.UpdateTask;
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
    [Route("/get-all-tasks")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponseDto<List<TasksDto>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ValidationModelResponseDto))]
    public async Task<IActionResult> GetAllTasks()
    {
        var response = await _sender.Send(new GetAllTasksQuery());
        return response.Match(
            Ok,
            Problem
        );
    }

    [HttpPost("/create-tasks")]   
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationModelResponseDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ValidationModelResponseDto))]
    public async Task<IActionResult> CreateTask(TasksDto tasksDto)
    {
        var response = await _sender.Send(new CreateTasksCommand(tasksDto));
        return response.Match(
            Ok,
            Problem
        );
    }


    [HttpPut("/update-tasks")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationModelResponseDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ValidationModelResponseDto))]
    public async Task<IActionResult> UpdateTask(TasksDto tasksDto)
    {
        var response = await _sender.Send(new UpdateTasksCommand(tasksDto));
        return response.Match(
            Ok,
            Problem
        );
    }

    [HttpDelete("/{tasksId}/delete-tasks")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationModelResponseDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ValidationModelResponseDto))]
    public async Task<IActionResult> DeleteTask(int tasksId)
    {
        var response = await _sender.Send(new DeleteTasksCommand(tasksId));
        return response.Match(
            Ok,
            Problem
        );
    }
}


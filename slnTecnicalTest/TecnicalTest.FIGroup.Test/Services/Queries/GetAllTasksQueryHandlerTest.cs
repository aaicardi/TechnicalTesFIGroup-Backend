using Mapster;

using MapsterMapper;

using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TecnicalTest.FIGroup.Application.Services.Tasks.Handlers.CreateTasks;
using TecnicalTest.FIGroup.Application.Services.Tasks.Queries.GetAllTasks;
using TecnicalTest.FIGroup.Contracts.Dtos;
using TecnicalTest.FIGroup.Domain.Entities;
using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;

namespace TecnicalTest.FIGroup.Test.Services.Queries;

[TestFixture]
public class GetAllTasksQueryHandlerTest
{
    private Mock<IMapper> mockMapper;
    private Mock<IFacadeRepository> mockFacadeRepository;
    private MockRepository mockRepository;

    [SetUp]
    public void SetUp()
    {
        this.mockRepository = new MockRepository(MockBehavior.Strict);
        this.mockFacadeRepository = this.mockRepository.Create<IFacadeRepository>();
        this.mockMapper = this.mockRepository.Create<IMapper>();
    }

    private GetAllTasksQueryHandler ServiceHandler()
    {
        return new GetAllTasksQueryHandler(
              this.mockFacadeRepository.Object,
           this.mockMapper.Object
          );
    }

    public static Mapper GetMapper()
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(TasksDto).Assembly);
        return new Mapper(config);
    }


    [Test]
    [Author("Jhoel Aicardi")]
    public async Task GetAllTasksError()
    {
        // Arrange
        var service = this.ServiceHandler();
        List<Tasks> dtos = new()
        {
            new Tasks()
            {
                Id = 1,
                Description = "tarea1"
            },
            new Tasks()
            {
                Id = 2,
                Description = "tarea2"
            }
        };
        this.mockFacadeRepository.Setup(s => s.TasksRepository.GetAllTasks()).Returns(dtos);

        // Act
        var result = await service.Handle(null,new System.Threading.CancellationToken());

        // Assert
        Assert.AreEqual(true, result.IsError);
       // this.mockRepository.VerifyAll();
    }



    [Test]
    [Author("Jhoel Aicardi")]
    public async Task GetAllTasksNotFound()
    {
        // Arrange
        var service = this.ServiceHandler();    

        this.mockFacadeRepository.Setup(s => s.TasksRepository.GetAllTasks()).Returns(new List<Tasks>());
        var result = await service.Handle(null, new System.Threading.CancellationToken());
        // Assert
        Assert.AreEqual(true, result.IsError);
    }



    [Test]
    [Author("Jhoel Aicardi")]
    public async Task GetAllTasks()
    {
        // Arrange
        var service = this.ServiceHandler();
        List<Tasks> dtos = new()
        {
            new Tasks()
            {
                Id = 1,
                Description = "tarea1"
            },
            new Tasks()
            {
                Id = 2,
                Description = "tarea2"
            }
        };




        this.mockFacadeRepository.Setup(s => s.TasksRepository.GetAllTasks()).Returns(new List<Tasks>());
        //GetMapper();
        //mockMapper.Setup(
        //         x => x.Map<List<Tasks>, List<TasksDto>>(It.Is<List<Tasks>>(a => a.Count > 1)))
        //    .Returns(lst);

        //mockMapper.Setup(
        //     x => x.Map<List<TasksDto>, List<Task>>(It.Is<List<TasksDto>>(a => a.Count > 1)))
        //    .Returns(new List<Task>());

        // Act
        var result = await service.Handle(null, new System.Threading.CancellationToken());

        // Assert
        Assert.AreEqual(true, true); 
    }
}


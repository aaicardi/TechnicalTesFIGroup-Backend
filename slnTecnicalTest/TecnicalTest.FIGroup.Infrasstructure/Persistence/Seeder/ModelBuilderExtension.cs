using Microsoft.EntityFrameworkCore;

using TecnicalTest.FIGroup.Domain.Entities;
using TecnicalTest.FIGroup.Domain.Enums;

namespace TecnicalTest.FIGroup.Infrastructure.Persistence.Seeder;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tasks>().HasData(
            new Tasks
            {
                Id = 1,
                Description = "Tarea de prueba",
                Status =  true,
                IsCompleted = false
            }
        );
    }
}


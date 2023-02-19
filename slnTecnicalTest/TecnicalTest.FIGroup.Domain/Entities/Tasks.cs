using TecnicalTest.FIGroup.Domain.Enums;

namespace TecnicalTest.FIGroup.Domain.Entities;

public class Tasks
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public LocaleStatusEnum Status { get; set; }
}


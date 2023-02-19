namespace TecnicalTest.FIGroup.Domain.Entities;

public class Tasks
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public bool Status { get; set; }
}


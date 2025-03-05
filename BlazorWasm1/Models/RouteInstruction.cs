namespace BlazorWasm1.Models;

public sealed record RouteInstruction
{
    public int Stage { get; set; }
    public string Description { get; set; }
}
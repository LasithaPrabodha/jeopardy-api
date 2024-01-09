namespace Jeopardy.Shared;

public class ClueParameters : RequestParameters
{
    public ClueParameters() => OrderBy = "Id";
    public string? SearchTerm { get; set; }
}
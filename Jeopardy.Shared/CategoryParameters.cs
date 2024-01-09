namespace Jeopardy.Shared.Shared;

public class CategoryParameters : RequestParameters
{
    public CategoryParameters() => OrderBy = "Id";
    public string? SearchTerm { get; set; }
}
namespace Jeopardy.API.Dto;

public class ClueDto
{
    public int Id { get; set; }
    public int Game { get; set; }
    public int Round { get; set; }
    public int Value { get; set; }
    public string Clue { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string? AirDate { get; set; }
}
namespace Jeopardy.Shared;

public class RandomClueParameters : RequestParameters
{
    public int Round { get; set; }

    public int Value { get; set; }

    public int Category { get; set; }
}
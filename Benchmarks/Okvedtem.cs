namespace Benchmarks;

public class Okvedtem
{
    public Okvedtem(string code, string description, string @group)
    {
        Code = code;
        Description = description;
        Group = @group;
    }

    public string Group { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }
}
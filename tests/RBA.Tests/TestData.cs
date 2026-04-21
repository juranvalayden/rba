namespace RBA.Tests;

public class TestData
{
    private static readonly string[] _sampleData = [
        "5 3",
        "",
        "1 1 E",
        "RFRFRFRF",
        "",
        "3 2 N",
        "FRRFLLFFRRFLL",
        "",
        "0 3 W",
        "LLFFFLFLFL",
        ""
    ];
    private static readonly string[] _sampleDataExpectedResults = [
        "1 1 E",
        "3 3 N LOST",
        "2 3 S"
    ];

    public static IEnumerable<string> GetSampleData => _sampleData;
    public static IEnumerable<string> GetSampleExpectedResults => _sampleDataExpectedResults;

    public static TheoryData<IEnumerable<string>, IEnumerable<string>> AsPerCodingChallenge() => new()
    {
        { _sampleData, _sampleDataExpectedResults }
    };
}
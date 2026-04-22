namespace RBA.Tests.UnitTests.TestData;

public static class RobotTestData
{
    private static readonly string[] _sampleData =
    [
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

    private static readonly string[] _sampleDataExpectedResults =
    [
        "1 1 E",
        "3 3 N LOST",
        "2 3 S"
    ];

    private static readonly string[] _generatedData1 =
    [
        "20 12",
        "",
        "2 14 N",
        "RFRFRFRFR",
        "",
        "19 9 S",
        "FFFFFFFFFFFFFFFFFFFFFFFFF",
        "",
        "19 10 N",
        "RFRFRFRFR",
        "",
        "16 16 W",
        "FFFFFFFFFFFFFFFFFFFFFFFFF",
        "",
        "4 7 E",
        "RFRFRFR"
    ];

    private static readonly string[] _generatedExpectedResults1 =
    [
        "2 14 E LOST",
        "19 0 S LOST",
        "19 10 E",
        "16 16 W LOST",
        "3 7 E"
    ];

    private static readonly string[] _generatedData2 =
    [
        "15 10",
        "",
        "5 5 N",
        "FFRFFRFF",
        "",
        "14 9 E",
        "FFFFFFFFFFFF",
        "",
        "0 0 S",
        "RFRFRFRF",
        "",
        "7 3 W",
        "FFLFFLFFL",
        "",
        "10 2 N",
        "FRFRFRFRFR"
    ];

    private static readonly string[] _generatedExpectedResults2 =
    [
        "7 7 N",
        "15 9 E LOST",
        "0 0 W",
        "4 3 S",
        "10 7 N"
    ];

    private static readonly string[] _generatedData3 =
    [
        "25 20",
        "",
        "12 10 E",
        "RFRFRFRFRFRFRF",
        "",
        "24 19 N",
        "FFFFFFFFFFFFFFFFF",
        "",
        "5 15 W",
        "LLFFLLFFLLFF",
        "",
        "20 0 S",
        "FRFRFRFRFRFRFR",
        "",
        "8 8 N",
        "FFRFFRFFRFF"
    ];

    private static readonly string[] _generatedExpectedResults3 =
    [
        "12 10 E",
        "24 20 N LOST",
        "1 15 E",
        "20 0 W",
        "12 12 N"
    ];

    public static List<object[]> SampleData => [[_sampleData, _sampleDataExpectedResults]];

    public static List<object[]> GeneratedData =>
    [
        [_generatedData1, _generatedExpectedResults1],
        [_generatedData2, _generatedExpectedResults2],
        [_generatedData3, _generatedExpectedResults3]
    ];
}
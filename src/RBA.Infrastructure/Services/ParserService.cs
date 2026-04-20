using RBA.Domain.Entities;
using RBA.Domain.Enums;
using RBA.Infrastructure.Interfaces;

namespace RBA.Infrastructure.Services;

public class ParserService : IParserService
{
    public ParsedData Parse(string[] lines)
    {
        if (lines.Length == 0) return CreateDefaultParsedData();

        var rawGridLine = lines.FirstOrDefault();

        if (rawGridLine is null) return CreateDefaultParsedData();

        var grid = CreateGrid(rawGridLine);

        var robots = lines
            .Skip(1)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Chunk(2)
            .Select(chunk => CreateRobot(chunk[0], chunk[1]));

        return new ParsedData(grid, robots);
    }

    public static ParsedData CreateDefaultParsedData()
    {
        return new ParsedData(new Grid(new Coordinate(0, 0)), []);
    }

    private static Robot CreateRobot(string rawStartingBlockString, string rawRobotInstructions)
    {
        var startingCoordinates = CreateCoordinate(rawStartingBlockString);

        var rawStaringBlockData = rawStartingBlockString.Split(' ', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();

        if (rawStaringBlockData is null) return CreateDefaultRobot();

        var isValidFacingCardinalType = Enum.TryParse<CardinalType>(rawStaringBlockData, true, out var facing);

        if (!isValidFacingCardinalType) return CreateDefaultRobot();

        var robotInstructions = rawRobotInstructions
            .Select(MapInstructions)
            .ToList();

        var areValidRobotInstructions = !robotInstructions.Contains(InstructionType.Unknown);

        return areValidRobotInstructions
            ? new Robot(startingCoordinates, facing, robotInstructions)
            : CreateDefaultRobot();
    }

    private static InstructionType MapInstructions(char rawMoveLine)
    {
        var isValidInstruction = Enum.TryParse(rawMoveLine.ToString(), true, out InstructionType instructionType);
        return isValidInstruction ? instructionType : InstructionType.Unknown;
    }

    private static Robot CreateDefaultRobot()
    {
        return new Robot(new Coordinate(0, 0), CardinalType.N, []);
    }

    private Grid CreateGrid(string rawGridLine)
    {
        // validation to be fleshed out
        // should have spaces and have exactly 2 items
        // lineData[0] and lineData[1] should be valid ints
        var coordinate = CreateCoordinate(rawGridLine);
        return new Grid(coordinate);
    }

    private static Coordinate CreateCoordinate(string rawCoordinateLine)
    {
        var lineData = rawCoordinateLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var isValidX = int.TryParse(lineData[0], out var x);
        var isValidY = int.TryParse(lineData[1], out var y);

        if (isValidX && isValidY)
        {
            return new Coordinate(x, y);
        }

        return new Coordinate(0, 0);
    }
}
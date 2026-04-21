using RBA.Domain.Entities;
using RBA.Domain.Enums;
using RBA.Infrastructure.Interfaces;

namespace RBA.Infrastructure.Services;

public class ParserService : IParserService
{
    public IEnumerable<RobotDataSet> Parse(string[] lines)
    {
        if (lines.Length == 0) return CreateDefaultRobotData();

        var rawGridLine = lines.FirstOrDefault();

        if (rawGridLine is null) return CreateDefaultRobotData();

        var grid = CreateGrid(rawGridLine);

        var robotData = lines
            .Skip(1)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Chunk(2)
            .Select(chunk => CreateRobotData(grid, chunk[0], chunk[1]));

        return robotData;
    }

    private static IEnumerable<RobotDataSet> CreateDefaultRobotData()
    {
        return [];
    }

    private RobotDataSet CreateRobotData(Grid grid, string rawStartingBlockString, string rawRobotInstructions)
    {
        var startingCoordinates = ParseCoordinate(rawStartingBlockString);

        var rawStaringBlockData = rawStartingBlockString.Split(' ', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();

        if (rawStaringBlockData is null) return CreateDefaultRobot();

        var isValidFacingCardinalType = Enum.TryParse<CardinalType>(rawStaringBlockData, true, out var facing);

        if (!isValidFacingCardinalType) return CreateDefaultRobot();

        var robotInstructions = rawRobotInstructions
            .Select(MapInstructions)
            .ToList();

        var areValidRobotInstructions = !robotInstructions.Contains(InstructionType.Unknown);

        var robot = new Robot(startingCoordinates, facing);

        return areValidRobotInstructions
            ? new RobotDataSet(grid, startingCoordinates, robot, robotInstructions)
            : CreateDefaultRobot();
    }

    private static InstructionType MapInstructions(char rawMoveLine)
    {
        var isValidInstruction = Enum.TryParse(rawMoveLine.ToString(), true, out InstructionType instructionType);
        return isValidInstruction ? instructionType : InstructionType.Unknown;
    }

    private static RobotDataSet CreateDefaultRobot()
    {
        var defaultCoordinate = new Coordinate(0, 0);
        var defaultGrid = new Grid(defaultCoordinate);
        var defaultRobot = new Robot(defaultCoordinate, CardinalType.N);

        return new RobotDataSet(defaultGrid, defaultCoordinate, defaultRobot, []);
    }

    private Grid CreateGrid(string rawGridLine)
    {
        // validation to be fleshed out
        // should have spaces and have exactly 2 items
        // lineData[0] and lineData[1] should be valid ints
        var coordinate = ParseCoordinate(rawGridLine);

        return new Grid(coordinate);
    }

    private static Coordinate ParseCoordinate(string rawCoordinateLine)
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
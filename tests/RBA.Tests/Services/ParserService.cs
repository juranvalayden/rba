using RBA.Tests.Entities;
using RBA.Tests.Interfaces;

namespace RBA.Tests.Services;

public class ParserService(IValidationService validationService) : IParserService
{
    private readonly IValidationService _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));

    public RobotDataSet[] Parse(string[] lines)
    {
        if (lines.Length == 0) throw new ArgumentNullException(nameof(lines));

        var rawGridLine = lines.FirstOrDefault();

        if (rawGridLine is null) throw new InvalidOperationException("No grid line found.");

        var grid = _validationService.ValidateGrid(rawGridLine);

        var robotDataSets = lines
            .Skip(1)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Chunk(2)
            .Select(chunk => CreateRobotData(grid, chunk[0], chunk[1]))
            .ToArray();

        return robotDataSets.Length == 0
            ? throw new InvalidOperationException("Robot data sets not created.")
            : robotDataSets;
    }

    private RobotDataSet CreateRobotData(Grid grid, string rawStartingBlockString, string rawRobotInstructions)
    {
        var startingBlock = _validationService.ValidateStartingBlock(grid, rawStartingBlockString);

        var facing = _validationService.ValidateCardinalType(rawStartingBlockString);

        var robotInstructions = _validationService.ValidateRobotInstructions(rawRobotInstructions);

        var robot = new Robot(startingBlock, facing);

        return new RobotDataSet(grid, startingBlock, robot, robotInstructions);
    }
}
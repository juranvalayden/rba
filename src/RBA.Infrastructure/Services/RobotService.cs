using RBA.Domain.Entities;
using RBA.Domain.Enums;
using RBA.Infrastructure.Interfaces;

namespace RBA.Infrastructure.Services;

public class RobotService(IParserService parserService, IMapService mapService) : IRobotService
{
    private readonly IParserService _parserService = parserService ?? throw new ArgumentNullException(nameof(parserService));
    private readonly IMapService _mapService = mapService ?? throw new ArgumentNullException(nameof(mapService));

    public string[] Execute(string[] rawInput)
    {
        var robotDataSets = _parserService
            .Parse(rawInput)
            .ToList();

        return robotDataSets
            .Select(x => ProcessRobotDataSet(x.Grid, x.Robot, x.Instructions))
            .ToArray();
    }

    private string ProcessRobotDataSet(Grid grid, Robot robot, IEnumerable<InstructionType> instructions)
    {
        CheckIfLost(grid.Coordinate, robot.CurrentCoordinate);
        
        if (robot.IsLost) return robot.ToString();

        foreach (var instruction in instructions)
        {
            if (robot.IsLost) break;

            ExecuteInstruction(grid, robot, instruction);
        }

        return robot.ToString();
    }

    public void ExecuteInstruction(Grid grid, Robot robot, InstructionType instruction)
    {
        switch (instruction)
        {
            case InstructionType.R:
                robot.Facing = TurnRight(robot.Facing);
                break;
            case InstructionType.L:
                robot.Facing = TurnLeft(robot.Facing);
                break;
            case InstructionType.F:
                robot.CurrentCoordinate = Move(grid, robot);
                break;
            case InstructionType.Unknown:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(instruction), instruction, null);
        }
    }

    public CardinalType TurnRight(CardinalType facing) =>
        _mapService.TurnRight(facing);

    public CardinalType TurnLeft(CardinalType facing) =>
        _mapService.TurnLeft(facing);

    public Coordinate Move(Grid grid, Robot robot)
    {
        var updateCoordinateWith = _mapService.GetUpdateCoordinateWith(robot.Facing);
        var newCoordinate = new Coordinate(robot.CurrentCoordinate.X + updateCoordinateWith.X, robot.CurrentCoordinate.Y + updateCoordinateWith.Y);

        var isLost = CheckIfLost(grid.Coordinate, newCoordinate);

        if (!isLost) return newCoordinate;

        var hasScent = grid.HasScent(robot.CurrentCoordinate, robot.Facing);
        if (hasScent) return robot.CurrentCoordinate;

        robot.IsLost = true;
        grid.AddScent(robot.CurrentCoordinate, robot.Facing);
        return robot.CurrentCoordinate;
    }

    public bool CheckIfLost(Coordinate gridCoordinate, Coordinate newCoordinate)
    {
        return newCoordinate.X < 0 || 
               newCoordinate.Y < 0 ||
               newCoordinate.X > gridCoordinate.X ||
               newCoordinate.Y > gridCoordinate.Y;
    }
}
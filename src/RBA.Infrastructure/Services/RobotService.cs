using RBA.Domain.Entities;
using RBA.Domain.Enums;
using RBA.Infrastructure.Interfaces;

namespace RBA.Infrastructure.Services;

public class RobotService : IRobotService
{
    private readonly IParserService _parserService;
    private readonly IMapService _mapService;

    private readonly HashSet<(Coordinate, CardinalType)> _scents = [];

    public RobotService(IParserService parserService, IMapService mapService)
    {
        _parserService = parserService ?? throw new ArgumentNullException(nameof(parserService));
        _mapService = mapService ?? throw new ArgumentNullException(nameof(mapService));
    }

    public IEnumerable<string> Execute(string[] input)
    {
        var parsedData = _parserService.Parse(input);

        var grid = parsedData.Grid;
        var robots = parsedData.Robots.ToList();
        var results = new List<string>();

        foreach (var robot in robots)
        {
            foreach (var instruction in robot.Instructions)
            {
                if (robot.IsLost) break;

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
                        throw new ArgumentOutOfRangeException();
                }
            }

            results.Add(robot.ToString());
        }

        return results;
    }

    public bool IsLost(Grid grid, Coordinate coordinate)
    {
        return coordinate.X < 0 ||
               coordinate.Y < 0 ||
               coordinate.X > grid.Coordinate.X ||
               coordinate.Y > grid.Coordinate.Y;
    }

    public CardinalType TurnRight(CardinalType facing) =>
        _mapService.TurnRight(facing);

    public CardinalType TurnLeft(CardinalType facing) =>
        _mapService.TurnLeft(facing);

    public Coordinate Move(Grid grid, Robot robot)
    {
        var delta = _mapService.GetUpdateCoordinateWith(robot.Facing);
        var newCoordinate = new Coordinate(
            robot.CurrentCoordinate.X + delta.X,
            robot.CurrentCoordinate.Y + delta.Y
        );

        var isLost = IsLost(grid, newCoordinate);

        if (!isLost) return newCoordinate;

        var hasScent = HasScent(robot.CurrentCoordinate, robot.Facing);

        if (hasScent) return robot.CurrentCoordinate;

        robot.IsLost = true;
        AddScent(robot.CurrentCoordinate, robot.Facing);
        return robot.CurrentCoordinate;
    }

    public bool HasScent(Coordinate coordinate, CardinalType facing) =>
        _scents.Contains((coordinate, facing));

    public void AddScent(Coordinate coordinate, CardinalType facing) => 
        _scents.Add((coordinate, facing));
}

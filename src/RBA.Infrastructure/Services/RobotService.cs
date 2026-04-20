using RBA.Domain.Entities;
using RBA.Domain.Enums;
using RBA.Infrastructure.Interfaces;

namespace RBA.Infrastructure.Services;

public class RobotService : IRobotService
{
    private readonly IParserService _parserService;
    private readonly IMapService _mapService;

    public RobotService(IParserService parserService, IMapService mapService)
    {
        _parserService = parserService ?? throw new ArgumentNullException(nameof(parserService));
        _mapService = mapService ?? throw new ArgumentNullException(nameof(mapService));
    }

    public IEnumerable<string> Execute(string[] input)
    {
        var parsedData = _parserService.Parse(input);

        // validate parsedData

        var grid = parsedData.Grid;
        var robots = parsedData.Robots;

        foreach (var robot in robots)
        {
            var robotStartingBlock = robot.StartingBlock;
            var robotInstructions = robot.Instructions;

            foreach (var robotInstructionType in robotInstructions)
            {
                switch (robotInstructionType)
                {
                    case InstructionType.Unknown:
                        break;
                    case InstructionType.R:
                        break;
                    case InstructionType.L:
                        break;
                    case InstructionType.F:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            switch (robot.Facing)
            {
                case CardinalType.Unknown:
                    break;
                case CardinalType.N:
                    break;
                case CardinalType.E:
                    break;
                case CardinalType.S:
                    break;
                case CardinalType.W:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return [];
    }

    public CardinalType TurnRight(CardinalType currentlyFacing)
    {
        return _mapService.TurnRight(currentlyFacing);
    }

    public CardinalType TurnLeft(CardinalType currentlyFacing)
    {
        return _mapService.TurnLeft(currentlyFacing);
    }

    public Coordinate Move(CardinalType cardinalType, Coordinate currentCoordinates)
    {
        var coordinate = _mapService.GetUpdateCoordinateWith(cardinalType);

        var newXCoordinate = currentCoordinates.X + coordinate.X;
        var newYCoordinate = currentCoordinates.Y + coordinate.Y;

        return new Coordinate(newXCoordinate, newYCoordinate);
    }
}
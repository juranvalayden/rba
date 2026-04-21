using RBA.Domain.Entities;
using RBA.Domain.Enums;
using RBA.Infrastructure.Interfaces;

namespace RBA.Infrastructure.Services;

public class ValidationService : IValidationService
{
    private const int _maxRobotInstructionLength = 100;
    private const int _intMaxCoordinateValue = 50;

    public Grid ValidateGrid(string line)
    {
        var gridCoordinates = ValidateCoordinates(line);

        var isInvalidGrid = gridCoordinates.X == gridCoordinates.Y;

        return isInvalidGrid
            ? throw new InvalidOperationException("Invalid grid values are equal")
            : new Grid(gridCoordinates);
    }

    public CardinalType ValidateCardinalType(string line)
    {
        if (string.IsNullOrWhiteSpace(line)) throw new InvalidOperationException("Starting facing direction not found.");

        var rawFacingCardinal = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();

        if (string.IsNullOrWhiteSpace(rawFacingCardinal)) throw new InvalidOperationException("Starting facing direction not found.");

        var isValidFacingCardinalType = Enum.TryParse<CardinalType>(rawFacingCardinal, true, out var facing);

        return !isValidFacingCardinalType ? throw new InvalidOperationException("Robot facing is invalid.") : facing;
    }

    public Coordinate ValidateStartingBlock(Grid grid, string line)
    {
        var startingCoordinates = ValidateCoordinates(line);

        var isLost = startingCoordinates.X > grid.Coordinate.X || startingCoordinates.Y > grid.Coordinate.Y;

        return isLost
            ? throw new InvalidOperationException("Robot is Lost.")
            : startingCoordinates;
    }

    public Coordinate ValidateCoordinates(string line)
    {
        var lineData = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var isValidX = int.TryParse(lineData[0], out var x);
        var isValidY = int.TryParse(lineData[1], out var y);

        if (!isValidX || !isValidY) throw new InvalidOperationException("Invalid coordinates.");

        if (x > _intMaxCoordinateValue || y > _intMaxCoordinateValue)
        {
            throw new InvalidOperationException($"Coordinate values should be <= {_intMaxCoordinateValue}.");
        }

        return new Coordinate(x, y);
    }

    public InstructionType[] ValidateRobotInstructions(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            throw new InvalidOperationException("No robot instructions can be found.");

        if (line.Length > _maxRobotInstructionLength)
            throw new InvalidOperationException("Robot instruction length exceeded 100.");

        var instructions = new List<InstructionType>();

        foreach (var robotInstruction in line)
        {
            var isValidInstruction = Enum.TryParse(robotInstruction.ToString(), true, out InstructionType instructionType);

            if (!isValidInstruction) throw new InvalidOperationException("Invalid robot instruction found.");

            instructions.Add(instructionType);
        }

        return instructions.ToArray();
    }
}
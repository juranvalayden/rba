using RBA.Tests.Entities;
using RBA.Tests.Enums;

namespace RBA.Tests.Interfaces;

public interface IValidationService
{
    Grid ValidateGrid(string line);
    Coordinate ValidateCoordinates(string line);
    CardinalType ValidateCardinalType(string line);
    Coordinate ValidateStartingBlock(Grid grid, string line);
    InstructionType[] ValidateRobotInstructions(string line);
}
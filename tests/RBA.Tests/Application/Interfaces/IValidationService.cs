using RBA.Tests.Domain.Entities;
using RBA.Tests.Domain.Enums;

namespace RBA.Tests.Application.Interfaces;

public interface IValidationService
{
    Grid ValidateGrid(string line);
    Coordinate ValidateCoordinates(string line);
    CardinalType ValidateCardinalType(string line);
    Coordinate ValidateStartingBlock(Grid grid, string line);
    InstructionType[] ValidateRobotInstructions(string line);
}
using RBA.Domain.Entities;
using RBA.Domain.Enums;

namespace RBA.Infrastructure.Interfaces;

public interface IValidationService
{
    Grid ValidateGrid(string line);
    CardinalType ValidateCardinalType(string line);
    Coordinate ValidateStartingBlock(Grid grid, string line);
    InstructionType[] ValidateRobotInstructions(string line);
}
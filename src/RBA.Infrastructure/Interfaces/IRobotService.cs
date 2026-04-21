using RBA.Domain.Entities;
using RBA.Domain.Enums;

namespace RBA.Infrastructure.Interfaces;

public interface IRobotService
{
    IEnumerable<string> Execute(string[] rawInput);

    void ExecuteInstruction(Grid grid, Robot robot, InstructionType instruction);

    CardinalType TurnRight(CardinalType currentlyFacing);
    CardinalType TurnLeft(CardinalType currentlyFacing);
    Coordinate Move(Grid grid, Robot robot);

    bool CheckIfLost(Coordinate gridCoordinate, Coordinate newCoordinate);
}
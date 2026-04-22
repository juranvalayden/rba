using RBA.Tests.Entities;
using RBA.Tests.Enums;

namespace RBA.Tests.Interfaces;

public interface IRobotService
{
    string[] Execute(string[] rawInput);

    void ExecuteInstruction(Grid grid, Robot robot, InstructionType instruction);

    CardinalType TurnRight(CardinalType currentlyFacing);
    CardinalType TurnLeft(CardinalType currentlyFacing);
    Coordinate Move(Grid grid, Robot robot);

    bool CheckIfLost(Coordinate gridCoordinate, Coordinate newCoordinate);
}
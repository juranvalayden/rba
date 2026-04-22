using RBA.Tests.Domain.Entities;
using RBA.Tests.Domain.Enums;

namespace RBA.Tests.Application.Interfaces;

public interface IRobotService
{
    string[] Execute(string[] rawInput);

    void ExecuteInstruction(Grid grid, Robot robot, InstructionType instruction);

    CardinalType TurnRight(CardinalType currentlyFacing);
    CardinalType TurnLeft(CardinalType currentlyFacing);
    Coordinate Move(Grid grid, Robot robot);

    bool CheckIfLost(Coordinate gridCoordinate, Coordinate newCoordinate);
}
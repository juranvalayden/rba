using RBA.Domain.Entities;
using RBA.Domain.Enums;

namespace RBA.Infrastructure.Interfaces;

public interface IRobotService
{
    CardinalType TurnRight(CardinalType currentlyFacing);
    CardinalType TurnLeft(CardinalType currentlyFacing);
    Coordinate Move(Grid grid, Robot robot);

    bool IsLost(Grid grid, Coordinate currentCoordinate);
    bool HasScent(Coordinate coordinate, CardinalType facing);
    void AddScent(Coordinate coordinate, CardinalType facing);
}
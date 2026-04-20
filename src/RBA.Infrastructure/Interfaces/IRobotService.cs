using RBA.Domain.Entities;
using RBA.Domain.Enums;

namespace RBA.Infrastructure.Interfaces;

public interface IRobotService
{
    CardinalType TurnRight(CardinalType currentlyFacing);
    CardinalType TurnLeft(CardinalType currentlyFacing);
    Coordinate Move(CardinalType currentlyFacing, Coordinate currentCoordinate);
}
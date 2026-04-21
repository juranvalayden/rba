using RBA.Domain.Enums;

namespace RBA.Domain.Entities;

public class Robot(Coordinate currentCoordinate, CardinalType facing)
{
    public CardinalType Facing { get; set; } = facing;
    public Coordinate CurrentCoordinate { get; set; } = currentCoordinate;
    public bool IsLost { get; set; }

    public override string ToString() =>
        $"{CurrentCoordinate.X} {CurrentCoordinate.Y} {Facing}" + (IsLost ? " LOST" : "");
}
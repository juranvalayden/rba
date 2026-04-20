using RBA.Domain.Enums;

namespace RBA.Domain.Entities;

public class Robot
{
    public Coordinate StartingBlock { get; }
    public Coordinate CurrentCoordinate { get; set; }
    public CardinalType Facing { get; set; }
    public IEnumerable<InstructionType> Instructions { get; }
    public bool IsLost { get; set; }

    public Robot(Coordinate startingBlock, CardinalType facing, IEnumerable<InstructionType> instructions)
    {
        StartingBlock = startingBlock ?? throw new ArgumentNullException(nameof(startingBlock));
        CurrentCoordinate = startingBlock;
        Facing = facing;
        Instructions = instructions ?? throw new ArgumentNullException(nameof(instructions));
    }

    public override string ToString() =>
        $"{CurrentCoordinate.X} {CurrentCoordinate.Y} {Facing}" + (IsLost ? " LOST" : "");
}
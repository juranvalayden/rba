using RBA.Domain.Enums;

namespace RBA.Domain.Entities;

public class Robot
{
    public Coordinate StartingBlock { get; set; }
    public CardinalType Facing { get; set; }
    public IEnumerable<InstructionType> Instructions { get; set; }

    public Robot(Coordinate startingBlock, CardinalType facing, IEnumerable<InstructionType> instructions)
    {
        StartingBlock = startingBlock;
        Facing = facing;
        Instructions = instructions;
    }
}
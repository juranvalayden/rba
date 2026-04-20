using RBA.Domain.Enums;

namespace RBA.Domain.Entities;

public class Robot
{
    public Coordinate StartingBlock { get; set; }
    public CardinalType Facing { get; set; }
    public string[] Instructions { get; set; }

    public Robot(Coordinate startingBlock, CardinalType facing, string[] instructions)
    {
        StartingBlock = startingBlock;
        Facing = facing;
        Instructions = instructions;
    }
}
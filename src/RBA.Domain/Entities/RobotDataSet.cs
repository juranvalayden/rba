using RBA.Domain.Enums;

namespace RBA.Domain.Entities;

public record RobotDataSet(Grid Grid, Coordinate StartingBlock, Robot Robot, IEnumerable<InstructionType> Instructions);
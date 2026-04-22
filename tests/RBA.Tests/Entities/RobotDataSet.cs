using RBA.Tests.Enums;

namespace RBA.Tests.Entities;

public record RobotDataSet(Grid Grid, Coordinate StartingBlock, Robot Robot, IEnumerable<InstructionType> Instructions);
using RBA.Tests.Domain.Enums;

namespace RBA.Tests.Domain.Entities;

public record RobotDataSet(Grid Grid, Coordinate StartingBlock, Robot Robot, IEnumerable<InstructionType> Instructions);
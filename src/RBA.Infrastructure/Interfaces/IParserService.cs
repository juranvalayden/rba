using RBA.Domain.Entities;

namespace RBA.Infrastructure.Interfaces;

public interface IParserService
{
    IEnumerable<RobotDataSet> Parse(string[] lines);
}
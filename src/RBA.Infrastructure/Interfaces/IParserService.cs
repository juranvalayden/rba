using RBA.Domain.Entities;

namespace RBA.Infrastructure.Interfaces;

public interface IParserService
{
    RobotDataSet[] Parse(string[] lines);
}
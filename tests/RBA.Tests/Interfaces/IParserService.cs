using RBA.Tests.Entities;

namespace RBA.Tests.Interfaces;

public interface IParserService
{
    RobotDataSet[] Parse(string[] lines);
}
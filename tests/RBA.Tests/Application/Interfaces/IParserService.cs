using RBA.Tests.Domain.Entities;

namespace RBA.Tests.Application.Interfaces;

public interface IParserService
{
    RobotDataSet[] Parse(string[] lines);
}
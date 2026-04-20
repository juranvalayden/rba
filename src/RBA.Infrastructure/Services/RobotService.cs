using RBA.Infrastructure.Interfaces;

namespace RBA.Infrastructure.Services;

public class RobotService : IRobotService
{
    private object parsedData;

    public RobotService(object parsedData)
    {
        this.parsedData = parsedData;
    }

    public IEnumerable<string> Execute()
    {
        throw new NotImplementedException();
    }
}
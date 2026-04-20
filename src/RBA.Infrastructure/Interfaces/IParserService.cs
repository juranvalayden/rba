using RBA.Domain.Entities;

namespace RBA.Infrastructure.Interfaces;

public interface IParserService
{
    ParsedData Parse(string[] lines);
}
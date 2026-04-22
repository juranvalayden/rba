using RBA.Tests.Enums;

namespace RBA.Tests.Entities;

public class Grid(Coordinate coordinate)
{
    private readonly HashSet<Scent> _scents = [];

    public Coordinate Coordinate { get; private set; } = coordinate;

    public HashSet<Scent> GetScents() => _scents;

    public bool HasScent(Coordinate coordinate, CardinalType facing)
    {
        return _scents.Any(x => x.Coordinate == coordinate && x.CardinalType == facing);
    }

    public void AddScent(Coordinate coordinate, CardinalType facing)
    {
        _scents.Add(new Scent(coordinate, facing));
    }
}
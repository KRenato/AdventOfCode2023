using System.Collections.ObjectModel;

namespace Common;

public class CoordinateMap<TMappedObject> : KeyedCollection<Coordinate, TMappedObject>
    where TMappedObject : IMappedObject
{
    public TMappedObject this[int x, int y] => this[new Coordinate(x, y)];

    protected override Coordinate GetKeyForItem(TMappedObject item)
    {
        return item.Coordinate;
    }

    public int GetXBoundary() => Dictionary?
        .Keys
        .Select(c => c.X)
        .Max() ?? 0;

    public int GetYBoundary() => Dictionary?
        .Keys
        .Select(c => c.Y)
        .Max() ?? 0;
}

using StrataCharter.Sim.World;

namespace StrataCharter.Sim.Pathfinding;

public static class GridPathfinder
{
  private static readonly MapPosition[] CardinalOffsets =
  [
    new(0, -1, 0),
    new(1, 0, 0),
    new(0, 1, 0),
    new(-1, 0, 0),
  ];

  /// <summary>
  /// Finds a same-layer cardinal path. Successful paths include both the start and destination positions.
  /// </summary>
  public static PathfindingResult FindPath(LayeredWorldGrid grid, MapPosition start, MapPosition destination)
  {
    ArgumentNullException.ThrowIfNull(grid);

    var validationFailure = ValidateRequest(grid, start, destination);
    if (validationFailure is not PathfindingFailureReason.None)
    {
      return PathfindingResult.Failure(validationFailure);
    }

    if (start == destination)
    {
      return PathfindingResult.Success([start]);
    }

    var openSet = new PriorityQueue<MapPosition, int>();
    var cameFrom = new Dictionary<MapPosition, MapPosition>();
    var bestKnownCost = new Dictionary<MapPosition, int>
    {
      [start] = 0,
    };
    var closedSet = new HashSet<MapPosition>();

    openSet.Enqueue(start, GetManhattanDistance(start, destination));

    while (openSet.TryDequeue(out var current, out _))
    {
      if (!closedSet.Add(current))
      {
        continue;
      }

      if (current == destination)
      {
        return PathfindingResult.Success(ReconstructPath(cameFrom, start, destination));
      }

      foreach (var neighbor in GetWalkableSameLayerNeighbors(grid, current))
      {
        var candidateCost = bestKnownCost[current] + 1;
        if (bestKnownCost.TryGetValue(neighbor, out var knownCost) && candidateCost >= knownCost)
        {
          continue;
        }

        cameFrom[neighbor] = current;
        bestKnownCost[neighbor] = candidateCost;
        openSet.Enqueue(neighbor, candidateCost + GetManhattanDistance(neighbor, destination));
      }
    }

    return PathfindingResult.Failure(PathfindingFailureReason.DestinationUnreachable);
  }

  private static PathfindingFailureReason ValidateRequest(
      LayeredWorldGrid grid,
      MapPosition start,
      MapPosition destination)
  {
    if (!grid.IsInBounds(start))
    {
      return PathfindingFailureReason.StartOutOfBounds;
    }

    if (!grid.IsInBounds(destination))
    {
      return PathfindingFailureReason.DestinationOutOfBounds;
    }

    if (start.Z != destination.Z)
    {
      return PathfindingFailureReason.DifferentLayers;
    }

    if (!grid.GetTile(start).IsWalkable)
    {
      return PathfindingFailureReason.StartNotWalkable;
    }

    if (!grid.GetTile(destination).IsWalkable)
    {
      return PathfindingFailureReason.DestinationNotWalkable;
    }

    return PathfindingFailureReason.None;
  }

  private static IEnumerable<MapPosition> GetWalkableSameLayerNeighbors(LayeredWorldGrid grid, MapPosition position)
  {
    foreach (var offset in CardinalOffsets)
    {
      var neighbor = new MapPosition(position.X + offset.X, position.Y + offset.Y, position.Z);
      if (grid.TryGetTile(neighbor, out var tile) && tile.IsWalkable)
      {
        yield return neighbor;
      }
    }
  }

  private static List<MapPosition> ReconstructPath(
      Dictionary<MapPosition, MapPosition> cameFrom,
      MapPosition start,
      MapPosition destination)
  {
    var path = new List<MapPosition> { destination };
    var current = destination;

    while (current != start)
    {
      current = cameFrom[current];
      path.Add(current);
    }

    path.Reverse();
    return path;
  }

  private static int GetManhattanDistance(MapPosition first, MapPosition second)
  {
    return Math.Abs(first.X - second.X) + Math.Abs(first.Y - second.Y);
  }
}

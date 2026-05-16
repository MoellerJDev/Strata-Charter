using StrataCharter.Sim.World;

namespace StrataCharter.Sim.Pathfinding;

public sealed class PathfindingResult
{
  private PathfindingResult(PathfindingFailureReason failureReason, IReadOnlyList<MapPosition> path)
  {
    FailureReason = failureReason;
    Path = path;
  }

  public bool Succeeded => FailureReason == PathfindingFailureReason.None;

  public PathfindingFailureReason FailureReason { get; }

  public IReadOnlyList<MapPosition> Path { get; }

  public static PathfindingResult Success(IEnumerable<MapPosition> path)
  {
    ArgumentNullException.ThrowIfNull(path);

    return new PathfindingResult(PathfindingFailureReason.None, path.ToArray());
  }

  public static PathfindingResult Failure(PathfindingFailureReason failureReason)
  {
    if (failureReason == PathfindingFailureReason.None)
    {
      throw new ArgumentException("Failure results require a non-success reason.", nameof(failureReason));
    }

    return new PathfindingResult(failureReason, Array.Empty<MapPosition>());
  }
}

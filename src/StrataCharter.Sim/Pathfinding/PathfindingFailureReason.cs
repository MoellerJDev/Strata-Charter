namespace StrataCharter.Sim.Pathfinding;

public enum PathfindingFailureReason
{
  None = 0,
  StartOutOfBounds,
  DestinationOutOfBounds,
  DifferentLayers,
  StartNotWalkable,
  DestinationNotWalkable,
  DestinationUnreachable,
}

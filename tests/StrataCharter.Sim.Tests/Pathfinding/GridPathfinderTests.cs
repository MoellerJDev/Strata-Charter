using StrataCharter.Sim.Pathfinding;
using StrataCharter.Sim.World;
using Xunit;

namespace StrataCharter.Sim.Tests.Pathfinding;

public sealed class GridPathfinderTests
{
  [Fact]
  public void FindPathFindsStraightPathAcrossOpenWalkableTiles()
  {
    var grid = new LayeredWorldGrid(width: 5, height: 1, layerCount: 1, defaultTile: Tile.Open);
    var start = new MapPosition(X: 0, Y: 0, Z: 0);
    var destination = new MapPosition(X: 4, Y: 0, Z: 0);

    var result = GridPathfinder.FindPath(grid, start, destination);

    AssertSuccessfulPath(
        result,
        [
          new MapPosition(X: 0, Y: 0, Z: 0),
          new MapPosition(X: 1, Y: 0, Z: 0),
          new MapPosition(X: 2, Y: 0, Z: 0),
          new MapPosition(X: 3, Y: 0, Z: 0),
          new MapPosition(X: 4, Y: 0, Z: 0),
        ]);
  }

  [Fact]
  public void FindPathFindsPathAroundNonWalkableTiles()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 3, layerCount: 1, defaultTile: Tile.Open);
    var blockedPosition = new MapPosition(X: 1, Y: 1, Z: 0);
    grid.SetTile(blockedPosition, Tile.Blocked);

    var result = GridPathfinder.FindPath(
        grid,
        start: new MapPosition(X: 0, Y: 1, Z: 0),
        destination: new MapPosition(X: 2, Y: 1, Z: 0));

    Assert.True(result.Succeeded);
    Assert.Equal(PathfindingFailureReason.None, result.FailureReason);
    Assert.Equal(new MapPosition(X: 0, Y: 1, Z: 0), result.Path[0]);
    Assert.Equal(new MapPosition(X: 2, Y: 1, Z: 0), result.Path[^1]);
    Assert.Equal(5, result.Path.Count);
    Assert.DoesNotContain(blockedPosition, result.Path);
    AssertPathUsesCardinalSameLayerSteps(result.Path);
  }

  [Fact]
  public void FindPathReturnsFailureWhenDestinationIsUnreachable()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 3, layerCount: 1, defaultTile: Tile.Open);
    grid.SetTile(new MapPosition(X: 1, Y: 0, Z: 0), Tile.Blocked);
    grid.SetTile(new MapPosition(X: 0, Y: 1, Z: 0), Tile.Blocked);

    var result = GridPathfinder.FindPath(
        grid,
        start: new MapPosition(X: 0, Y: 0, Z: 0),
        destination: new MapPosition(X: 2, Y: 2, Z: 0));

    AssertFailure(result, PathfindingFailureReason.DestinationUnreachable);
  }

  [Fact]
  public void FindPathReturnsFailureWhenStartIsOutOfBounds()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 3, layerCount: 1, defaultTile: Tile.Open);

    var result = GridPathfinder.FindPath(
        grid,
        start: new MapPosition(X: -1, Y: 0, Z: 0),
        destination: new MapPosition(X: 2, Y: 2, Z: 0));

    AssertFailure(result, PathfindingFailureReason.StartOutOfBounds);
  }

  [Fact]
  public void FindPathReturnsFailureWhenDestinationIsOutOfBounds()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 3, layerCount: 1, defaultTile: Tile.Open);

    var result = GridPathfinder.FindPath(
        grid,
        start: new MapPosition(X: 0, Y: 0, Z: 0),
        destination: new MapPosition(X: 3, Y: 0, Z: 0));

    AssertFailure(result, PathfindingFailureReason.DestinationOutOfBounds);
  }

  [Fact]
  public void FindPathReturnsFailureWhenStartIsNotWalkable()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 3, layerCount: 1, defaultTile: Tile.Open);
    grid.SetTile(new MapPosition(X: 0, Y: 0, Z: 0), Tile.SolidRock);

    var result = GridPathfinder.FindPath(
        grid,
        start: new MapPosition(X: 0, Y: 0, Z: 0),
        destination: new MapPosition(X: 2, Y: 2, Z: 0));

    AssertFailure(result, PathfindingFailureReason.StartNotWalkable);
  }

  [Fact]
  public void FindPathReturnsFailureWhenDestinationIsNotWalkable()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 3, layerCount: 1, defaultTile: Tile.Open);
    grid.SetTile(new MapPosition(X: 2, Y: 2, Z: 0), Tile.SolidRock);

    var result = GridPathfinder.FindPath(
        grid,
        start: new MapPosition(X: 0, Y: 0, Z: 0),
        destination: new MapPosition(X: 2, Y: 2, Z: 0));

    AssertFailure(result, PathfindingFailureReason.DestinationNotWalkable);
  }

  [Fact]
  public void FindPathRejectsCrossLayerRequests()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 3, layerCount: 2, defaultTile: Tile.Open);

    var result = GridPathfinder.FindPath(
        grid,
        start: new MapPosition(X: 0, Y: 0, Z: 0),
        destination: new MapPosition(X: 0, Y: 0, Z: 1));

    AssertFailure(result, PathfindingFailureReason.DifferentLayers);
  }

  [Fact]
  public void FindPathReturnsSinglePositionWhenStartAndDestinationAreIdentical()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 3, layerCount: 1, defaultTile: Tile.Open);
    var position = new MapPosition(X: 1, Y: 1, Z: 0);

    var result = GridPathfinder.FindPath(grid, position, position);

    AssertSuccessfulPath(result, [position]);
  }

  private static void AssertSuccessfulPath(PathfindingResult result, IReadOnlyList<MapPosition> expectedPath)
  {
    Assert.True(result.Succeeded);
    Assert.Equal(PathfindingFailureReason.None, result.FailureReason);
    Assert.Equal(expectedPath, result.Path);
    AssertPathUsesCardinalSameLayerSteps(result.Path);
  }

  private static void AssertFailure(PathfindingResult result, PathfindingFailureReason expectedFailureReason)
  {
    Assert.False(result.Succeeded);
    Assert.Equal(expectedFailureReason, result.FailureReason);
    Assert.Empty(result.Path);
  }

  private static void AssertPathUsesCardinalSameLayerSteps(IReadOnlyList<MapPosition> path)
  {
    for (var index = 1; index < path.Count; index++)
    {
      var previous = path[index - 1];
      var current = path[index];
      var distance = Math.Abs(previous.X - current.X) + Math.Abs(previous.Y - current.Y);

      Assert.Equal(previous.Z, current.Z);
      Assert.Equal(1, distance);
    }
  }
}

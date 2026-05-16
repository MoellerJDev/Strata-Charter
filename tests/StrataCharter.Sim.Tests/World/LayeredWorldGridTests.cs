using StrataCharter.Sim.World;
using Xunit;

namespace StrataCharter.Sim.Tests.World;

public sealed class LayeredWorldGridTests
{
  [Fact]
  public void ConstructorStoresDimensionsAndInitializesDefaultTiles()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 2, layerCount: 4, defaultTile: Tile.SolidRock);

    Assert.Equal(3, grid.Width);
    Assert.Equal(2, grid.Height);
    Assert.Equal(4, grid.LayerCount);
    Assert.Equal(Tile.SolidRock, grid.GetTile(new MapPosition(X: 2, Y: 1, Z: 3)));
  }

  [Theory]
  [InlineData(0, 0, 0)]
  [InlineData(2, 1, 3)]
  public void IsInBoundsReturnsTrueForValidPositions(int x, int y, int z)
  {
    var grid = new LayeredWorldGrid(width: 3, height: 2, layerCount: 4, defaultTile: Tile.Open);

    Assert.True(grid.IsInBounds(new MapPosition(x, y, z)));
  }

  [Theory]
  [InlineData(-1, 0, 0)]
  [InlineData(3, 0, 0)]
  [InlineData(0, -1, 0)]
  [InlineData(0, 2, 0)]
  [InlineData(0, 0, -1)]
  [InlineData(0, 0, 4)]
  public void IsInBoundsReturnsFalseForInvalidPositions(int x, int y, int z)
  {
    var grid = new LayeredWorldGrid(width: 3, height: 2, layerCount: 4, defaultTile: Tile.Open);

    Assert.False(grid.IsInBounds(new MapPosition(x, y, z)));
  }

  [Fact]
  public void GetTileThrowsForInvalidPosition()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 2, layerCount: 4, defaultTile: Tile.Open);

    Assert.Throws<ArgumentOutOfRangeException>(() => grid.GetTile(new MapPosition(X: 3, Y: 0, Z: 0)));
  }

  [Fact]
  public void TryGetTileReturnsFalseForInvalidPosition()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 2, layerCount: 4, defaultTile: Tile.Open);

    var result = grid.TryGetTile(new MapPosition(X: 3, Y: 0, Z: 0), out var tile);

    Assert.False(result);
    Assert.Equal(default, tile);
  }

  [Fact]
  public void SetTileUpdatesTileAtPosition()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 2, layerCount: 4, defaultTile: Tile.SolidRock);
    var position = new MapPosition(X: 1, Y: 1, Z: 2);

    grid.SetTile(position, Tile.Open);

    Assert.Equal(Tile.Open, grid.GetTile(position));
  }

  [Fact]
  public void SetTileThrowsForInvalidPosition()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 2, layerCount: 4, defaultTile: Tile.Open);

    Assert.Throws<ArgumentOutOfRangeException>(() => grid.SetTile(new MapPosition(X: -1, Y: 0, Z: 0), Tile.SolidRock));
  }

  [Fact]
  public void TrySetTileReturnsFalseForInvalidPosition()
  {
    var grid = new LayeredWorldGrid(width: 3, height: 2, layerCount: 4, defaultTile: Tile.Open);

    var result = grid.TrySetTile(new MapPosition(X: -1, Y: 0, Z: 0), Tile.SolidRock);

    Assert.False(result);
  }

  [Theory]
  [InlineData(0, 1, 1)]
  [InlineData(1, 0, 1)]
  [InlineData(1, 1, 0)]
  public void ConstructorRejectsNonPositiveDimensions(int width, int height, int layerCount)
  {
    Assert.Throws<ArgumentOutOfRangeException>(
        () => new LayeredWorldGrid(width, height, layerCount, defaultTile: Tile.Open));
  }
}


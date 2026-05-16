using StrataCharter.Sim.World;
using Xunit;

namespace StrataCharter.Sim.Tests.World;

public sealed class LayeredWorldGridFactoryTests
{
  [Fact]
  public void CreateSurfaceAndUndergroundPreservesRequestedDimensions()
  {
    var grid = LayeredWorldGridFactory.CreateSurfaceAndUnderground(width: 4, height: 3, layerCount: 5);

    Assert.Equal(4, grid.Width);
    Assert.Equal(3, grid.Height);
    Assert.Equal(5, grid.LayerCount);
  }

  [Fact]
  public void CreateSurfaceAndUndergroundInitializesSurfaceLayerAsOpen()
  {
    var grid = LayeredWorldGridFactory.CreateSurfaceAndUnderground(width: 4, height: 3, layerCount: 5);

    for (var y = 0; y < grid.Height; y++)
    {
      for (var x = 0; x < grid.Width; x++)
      {
        Assert.Equal(Tile.Open, grid.GetTile(new MapPosition(x, y, Z: 0)));
      }
    }
  }

  [Fact]
  public void CreateSurfaceAndUndergroundInitializesUndergroundLayersAsSolidRock()
  {
    var grid = LayeredWorldGridFactory.CreateSurfaceAndUnderground(width: 4, height: 3, layerCount: 5);

    for (var z = 1; z < grid.LayerCount; z++)
    {
      for (var y = 0; y < grid.Height; y++)
      {
        for (var x = 0; x < grid.Width; x++)
        {
          Assert.Equal(Tile.SolidRock, grid.GetTile(new MapPosition(x, y, z)));
        }
      }
    }
  }

  [Fact]
  public void CreateSurfaceAndUndergroundInitializesEveryValidCoordinateConsistently()
  {
    var grid = LayeredWorldGridFactory.CreateSurfaceAndUnderground(width: 3, height: 2, layerCount: 4);

    for (var z = 0; z < grid.LayerCount; z++)
    {
      var expectedTile = z == 0 ? Tile.Open : Tile.SolidRock;

      for (var y = 0; y < grid.Height; y++)
      {
        for (var x = 0; x < grid.Width; x++)
        {
          Assert.Equal(expectedTile, grid.GetTile(new MapPosition(x, y, z)));
        }
      }
    }
  }

  [Fact]
  public void CreateSurfaceAndUndergroundUsesCustomLayerTiles()
  {
    var undergroundTile = new Tile(IsSolid: true, IsWalkable: false, IsMineable: false);

    var grid = LayeredWorldGridFactory.CreateSurfaceAndUnderground(
        width: 2,
        height: 2,
        layerCount: 2,
        surfaceTile: Tile.Blocked,
        undergroundTile: undergroundTile);

    Assert.Equal(Tile.Blocked, grid.GetTile(new MapPosition(X: 0, Y: 0, Z: 0)));
    Assert.Equal(undergroundTile, grid.GetTile(new MapPosition(X: 0, Y: 0, Z: 1)));
  }

  [Theory]
  [InlineData(0, 1, 2)]
  [InlineData(1, 0, 2)]
  [InlineData(1, 1, 0)]
  [InlineData(1, 1, 1)]
  public void CreateSurfaceAndUndergroundRejectsInvalidDimensions(int width, int height, int layerCount)
  {
    Assert.Throws<ArgumentOutOfRangeException>(
        () => LayeredWorldGridFactory.CreateSurfaceAndUnderground(width, height, layerCount));
  }
}


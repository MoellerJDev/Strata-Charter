namespace StrataCharter.Sim.World;

/// <summary>
/// Creates deterministic layered world grids for early simulation and prototype work.
/// </summary>
public static class LayeredWorldGridFactory
{
  public static LayeredWorldGrid CreateSurfaceAndUnderground(int width, int height, int layerCount)
  {
    return CreateSurfaceAndUnderground(
        width,
        height,
        layerCount,
        surfaceTile: Tile.Open,
        undergroundTile: Tile.SolidRock);
  }

  public static LayeredWorldGrid CreateSurfaceAndUnderground(
      int width,
      int height,
      int layerCount,
      Tile surfaceTile,
      Tile undergroundTile)
  {
    if (layerCount < 2)
    {
      throw new ArgumentOutOfRangeException(
          nameof(layerCount),
          layerCount,
          "A surface-and-underground grid requires at least two layers.");
    }

    var grid = new LayeredWorldGrid(width, height, layerCount, undergroundTile);

    for (var y = 0; y < height; y++)
    {
      for (var x = 0; x < width; x++)
      {
        grid.SetTile(new MapPosition(x, y, Z: 0), surfaceTile);
      }
    }

    return grid;
  }
}


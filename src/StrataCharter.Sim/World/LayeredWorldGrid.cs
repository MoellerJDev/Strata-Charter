namespace StrataCharter.Sim.World;

/// <summary>
/// A bounded, simulation-owned grid of tiles across discrete z-layers.
/// </summary>
public sealed class LayeredWorldGrid
{
  private readonly Tile[] _tiles;

  public LayeredWorldGrid(int width, int height, int layerCount, Tile defaultTile)
  {
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(width);
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(height);
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(layerCount);

    Width = width;
    Height = height;
    LayerCount = layerCount;

    _tiles = Enumerable.Repeat(defaultTile, checked(width * height * layerCount)).ToArray();
  }

  public int Width { get; }

  public int Height { get; }

  public int LayerCount { get; }

  public bool IsInBounds(MapPosition position)
  {
    return position.X >= 0
        && position.X < Width
        && position.Y >= 0
        && position.Y < Height
        && position.Z >= 0
        && position.Z < LayerCount;
  }

  public Tile GetTile(MapPosition position)
  {
    if (!TryGetTile(position, out var tile))
    {
      throw new ArgumentOutOfRangeException(nameof(position), position, "Position is outside the grid bounds.");
    }

    return tile;
  }

  public bool TryGetTile(MapPosition position, out Tile tile)
  {
    if (!IsInBounds(position))
    {
      tile = default;
      return false;
    }

    tile = _tiles[GetIndex(position)];
    return true;
  }

  public void SetTile(MapPosition position, Tile tile)
  {
    if (!TrySetTile(position, tile))
    {
      throw new ArgumentOutOfRangeException(nameof(position), position, "Position is outside the grid bounds.");
    }
  }

  public bool TrySetTile(MapPosition position, Tile tile)
  {
    if (!IsInBounds(position))
    {
      return false;
    }

    _tiles[GetIndex(position)] = tile;
    return true;
  }

  private int GetIndex(MapPosition position)
  {
    return (position.Z * Height + position.Y) * Width + position.X;
  }
}


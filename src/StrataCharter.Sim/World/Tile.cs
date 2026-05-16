namespace StrataCharter.Sim.World;

/// <summary>
/// Minimal simulation-owned tile state for early layered world behavior.
/// </summary>
public readonly record struct Tile(bool IsSolid, bool IsWalkable, bool IsMineable)
{
  public static Tile Open { get; } = new(IsSolid: false, IsWalkable: true, IsMineable: false);

  public static Tile SolidRock { get; } = new(IsSolid: true, IsWalkable: false, IsMineable: true);

  public static Tile Blocked { get; } = new(IsSolid: false, IsWalkable: false, IsMineable: false);
}


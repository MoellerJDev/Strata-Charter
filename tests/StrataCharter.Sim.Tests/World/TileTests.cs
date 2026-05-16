using StrataCharter.Sim.World;
using Xunit;

namespace StrataCharter.Sim.Tests.World;

public sealed class TileTests
{
  [Fact]
  public void OpenTileIsWalkableAndNotMineable()
  {
    Assert.False(Tile.Open.IsSolid);
    Assert.True(Tile.Open.IsWalkable);
    Assert.False(Tile.Open.IsMineable);
  }

  [Fact]
  public void SolidRockIsSolidMineableAndNotWalkable()
  {
    Assert.True(Tile.SolidRock.IsSolid);
    Assert.False(Tile.SolidRock.IsWalkable);
    Assert.True(Tile.SolidRock.IsMineable);
  }

  [Fact]
  public void CustomTilePreservesStateFlags()
  {
    var tile = new Tile(IsSolid: true, IsWalkable: false, IsMineable: false);

    Assert.True(tile.IsSolid);
    Assert.False(tile.IsWalkable);
    Assert.False(tile.IsMineable);
  }
}


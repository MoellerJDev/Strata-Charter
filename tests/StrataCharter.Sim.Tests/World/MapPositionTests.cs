using StrataCharter.Sim.World;
using Xunit;

namespace StrataCharter.Sim.Tests.World;

public sealed class MapPositionTests
{
  [Fact]
  public void EqualCoordinatesHaveValueSemantics()
  {
    var first = new MapPosition(X: 2, Y: 3, Z: 1);
    var second = new MapPosition(X: 2, Y: 3, Z: 1);

    Assert.Equal(first, second);
    Assert.Equal(first.GetHashCode(), second.GetHashCode());
  }

  [Fact]
  public void DifferentLayersAreDifferentPositions()
  {
    var surface = new MapPosition(X: 2, Y: 3, Z: 0);
    var lowerLayer = new MapPosition(X: 2, Y: 3, Z: 1);

    Assert.NotEqual(surface, lowerLayer);
  }
}


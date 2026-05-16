using StrataCharter.Sim;
using Xunit;

namespace StrataCharter.Sim.Tests;

public sealed class SimulationAssemblyTests
{
  [Fact]
  public void AssemblyMarkerIdentifiesSimulationProject()
  {
    Assert.Equal("StrataCharter.Sim", SimulationAssembly.Name);
  }
}

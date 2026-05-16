using StrataCharter.Sim;
using Xunit;

namespace StrataCharter.Sim.Tests;

public sealed class ArchitectureBoundaryTests
{
  [Fact]
  public void SimulationAssemblyDoesNotReferenceGodot()
  {
    var references = typeof(SimulationAssembly).Assembly.GetReferencedAssemblies();

    Assert.DoesNotContain(
        references,
        reference => reference.Name?.StartsWith("Godot", StringComparison.OrdinalIgnoreCase) == true);
  }
}


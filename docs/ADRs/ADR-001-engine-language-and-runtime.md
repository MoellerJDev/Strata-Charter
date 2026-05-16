# ADR-001: Engine, Language, and Runtime

Status: Accepted

## Context

Strata Charter is a layered colony simulation with a dense UI, isometric presentation, and a long-lived simulation core. The design and technical documents call for Godot 4.6+ .NET edition, C# / .NET 8+, and desktop-first development.

## Decision

Use Godot 4.6+ .NET edition for presentation and C# targeting `net8.0` for project code.

The repository will not add `global.json` at this stage. The project requires .NET 8 or newer, but contributors may use newer SDKs that can build `net8.0` projects. Add `global.json` later only if the team needs exact SDK reproducibility.

## Consequences

- Godot owns rendering, input, audio, scenes, and presentation orchestration.
- The .NET projects can be built and tested with normal `dotnet` commands.
- Keeping `net8.0` as the target avoids requiring newer runtimes than the current technical direction needs.
- SDK reproducibility is intentionally deferred until the project has stronger CI or release needs.


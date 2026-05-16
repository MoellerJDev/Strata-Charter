# ADR-003: Repository Build Rails

Status: Accepted

## Context

Early Codex tasks will add many small systems. Without shared repository defaults, formatting, package versions, and analyzer settings can drift before the simulation architecture stabilizes.

## Decision

Use repository-level configuration for baseline engineering consistency:

- `Directory.Build.props` enables nullable reference types, implicit usings, analyzers, and build-time style enforcement.
- `Directory.Packages.props` centralizes NuGet package versions.
- `.editorconfig` records shared formatting and C# style preferences.

## Consequences

- Project files stay smaller and package upgrades happen in one place.
- Nullable and analyzer feedback is available from the first real simulation tasks.
- The settings are intentionally moderate: warnings are not treated as errors yet, so Godot integration and early prototyping are not over-constrained.


# ADR-002: Simulation Boundary

Status: Accepted

## Context

The central architecture rule is that the simulation core must not depend on Godot. Future systems such as layered maps, settlers, jobs, pathfinding, hazards, content-driven definitions, cognition, and campaign outcomes need deterministic tests and should be usable without launching the engine.

## Decision

`StrataCharter.Sim` is the authoritative engine-agnostic simulation assembly. It must not reference Godot packages or APIs.

`StrataCharter.Game` is the Godot presentation project. It may later reference `StrataCharter.Sim` and `StrataCharter.Content` when a presentation bridge is needed, but the baseline keeps those references absent until there is a concrete integration point.

`StrataCharter.Content` exists as a minimal future home for content loading, validation, and schemas. It should not become a parallel simulation layer.

## Consequences

- Simulation behavior should be introduced first in `StrataCharter.Sim` with automated tests.
- Godot scripts should translate input and render state rather than owning game rules.
- Future project references should point inward deliberately; avoid circular references.
- Architecture boundary tests should guard the no-Godot dependency rule.


# Strata Charter

**Strata Charter** is a persistent-world, layered colony roguelite set in an ancient, multi-species industrial science-fantasy universe.

Each settlement begins as a vulnerable frontier expedition on a hostile planet. Over time, it grows into a layered industrial colony shaped by geology, species composition, political pressure, and the escalating temptation to delegate more of itself to machine cognition. Successful settlements persist as part of the planetary campaign. Failed settlements become ruins, scars, and future stories.

## Current Status

**Pre-production / repository baseline established**

The project currently has its core design, technical direction, MVP implementation roadmap, and initial repository scaffold defined. Development should focus next on validating the layered colony simulation foundation before expanding into broader gameplay systems.

## Project Pillars

- **The settlement is the roguelike build**
  - Each colony develops a unique identity through site conditions, discoveries, doctrine choices, species mix, and cognition architecture.

- **Individuals carry the story**
  - Settlers matter as founders, operators, specialists, survivors, martyrs, and future historical figures.

- **Depth is progression**
  - The world is built around discrete z-layers. Descending changes resources, threats, ecologies, and long-term strategy.

- **Industry is survival**
  - Extraction, processing, logistics, vertical freight, and infrastructure are central to colony growth.

- **Delegation is dangerous**
  - As settlements scale, machine cognition becomes increasingly useful and increasingly risky.

- **The planet persists**
  - Chartered settlements, failed colonies, faction relationships, and ruins shape future expeditions.

## Core Setting Premise

The galaxy is old, crowded, and not human-centric. Multiple intelligent species inhabit a fragmented interstellar order that can cross space but still struggles to establish durable frontier colonies.

A central truth of the setting is that sufficiently complex synthetic minds attract the attention of a cosmic entity, force, or noetic ecology that treats artificial consciousness as an existential violation. Civilization has learned to restrict machine cognition, but expansion, industry, and logistics continuously tempt settlements to cross the line.

## Technology Direction

- **Engine:** Godot 4.6+ .NET edition
- **Language:** C# / .NET 8+
- **Architecture:** Engine-agnostic simulation core, with Godot used for presentation, input, UI, and audio
- **Initial platform target:** Desktop

The simulation core should remain independent of Godot wherever practical. The repository is intended to support long-term work on layered maps, settler simulation, jobs, industry, hazards, cognition/delegation systems, and persistent planetary campaign state.

## Repository Documents

Project direction and implementation expectations are defined in:

- [`AGENTS.md`](AGENTS.md)
  - Codex and contributor guidance
  - Coding standards
  - Architecture expectations
  - Task execution norms

- [`docs/GAME_DESIGN.md`](docs/GAME_DESIGN.md)
  - Full game concept
  - Core loops
  - Lore framework
  - Species and factions
  - Settlement lifecycle
  - Roguelike systems

- [`docs/TECHNICAL_ARCHITECTURE.md`](docs/TECHNICAL_ARCHITECTURE.md)
  - Engine and language choice
  - Simulation/presentation separation
  - Data model direction
  - Testing philosophy
  - Performance posture
  - Persistence architecture

- [`docs/MVP_ROADMAP.md`](docs/MVP_ROADMAP.md)
  - MVP thesis
  - Included and excluded scope
  - Milestones
  - Suggested task sequencing
  - Prototype success criteria

- [`docs/ADRs/`](docs/ADRs/)
  - Accepted architecture decisions
  - Baseline engine/runtime choice
  - Simulation boundary rules
  - Repository build conventions

## Initial Development Focus

The current scaffold establishes the build foundation:

- Godot project scaffold under `src/StrataCharter.Game/`
- engine-agnostic simulation library under `src/StrataCharter.Sim/`
- minimal future content/data library under `src/StrataCharter.Content/`
- simulation test project under `tests/StrataCharter.Sim.Tests/`
- repo-level .NET solution: `StrataCharter.sln`
- repo-level style and build configuration:
  - `.editorconfig`
  - `Directory.Build.props`
  - `Directory.Packages.props`
- initial architecture decision records under `docs/ADRs/`

The next implementation phase should start with layered grid primitives and a basic rendering bridge between the simulation and Godot.

Gameplay implementation should remain incremental and follow the roadmap rather than attempting to build the full colony sim immediately.

## Repository Structure

```text
/
  .editorconfig
  AGENTS.md
  Directory.Build.props
  Directory.Packages.props
  README.md
  StrataCharter.sln
  docs/
    ADRs/
    GAME_DESIGN.md
    TECHNICAL_ARCHITECTURE.md
    MVP_ROADMAP.md
  src/
    StrataCharter.Game/
    StrataCharter.Sim/
    StrataCharter.Content/
  tests/
    StrataCharter.Sim.Tests/
```

The exact structure may evolve as the prototype matures, but the separation between simulation code and engine-facing presentation should remain a core rule.

## Development Philosophy

Strata Charter should be built around a few disciplined priorities:

- Prove the colony loop before expanding scope.
- Keep central simulation systems testable.
- Preserve the layered-world concept from the start.
- Avoid burying game logic in presentation scripts.
- Prefer coherent, incremental milestones over speculative overengineering.
- Make systems support future persistence, revisiting, and settlement legacy wherever practical.

## MVP Goal

The first playable proof of concept should demonstrate:

- A small expedition landing in a hostile environment
- Digging and building across layered terrain
- Settlers autonomously performing useful jobs
- One meaningful industrial chain
- One vertical logistics problem
- One environmental or structural hazard
- One cognition/delegation decision
- A success or failure outcome that can be saved as a future campaign stub

See [`docs/MVP_ROADMAP.md`](docs/MVP_ROADMAP.md) for details.

## Getting Started

Prerequisites:

- .NET 8 SDK or newer
- Godot 4.6+ .NET edition for opening and running the Godot project

```bash
dotnet build StrataCharter.sln
dotnet test StrataCharter.sln
```

Package versions are managed centrally in `Directory.Packages.props`. Nullable reference types, implicit usings, and analyzer settings are managed in `Directory.Build.props`.

To open the Godot project, launch Godot 4.6+ .NET edition and import:

```text
src/StrataCharter.Game/project.godot
```

The current Godot scene displays a deterministic debug layered grid sourced from `StrataCharter.Sim`, including a surface-layer path overlay driven by the simulation pathfinder. Run the main scene and use `Q` / `E` to switch the visible layer.

## Working Title

**Strata Charter**

The name reflects the game’s two defining ideas:

- **Strata**: layered planetary depth, excavation, and buried histories
- **Charter**: expeditionary settlements that become lasting parts of a persistent planetary campaign

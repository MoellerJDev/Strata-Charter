# AGENTS.md

## Project: Strata Charter

Strata Charter is a persistent-world, layered colony roguelite set in a mythic industrial science-fantasy universe. Each settlement begins as a desperate frontier expedition, grows into a complex industrial colony, and becomes part of a persistent planetary campaign as a chartered settlement, a troubled long-lived colony, or a ruin that can shape later runs.

The project’s design bible lives in:

- `docs/GAME_DESIGN.md`

Codex should treat that document as the source of truth for gameplay intent, terminology, and feature direction. When a task requires a design decision not covered there, prefer the smallest implementation that is consistent with the document and note the assumption in the final response.

---

# 1. Current Technical Direction

## Engine and language

- Engine: **Godot 4.6+ .NET edition**
- Language: **C# / .NET 8+**
- Target platforms initially: desktop first

## Core architecture principle

> The simulation core must not depend on Godot.

Godot is the presentation/input/audio layer. The colony simulation, campaign simulation, pathfinding, job selection, world state, resource systems, and persistence models should live in plain C# projects wherever practical.

---

# 2. Expected Repository Structure

Use this as the default target shape unless the repository already establishes something different.

```text
/
  AGENTS.md
  README.md
  docs/
    GAME_DESIGN.md
    TECHNICAL_ARCHITECTURE.md        # optional initially, recommended as the codebase grows
    ADRs/                            # architecture decision records, if added later
  src/
    StrataCharter.Game/              # Godot project and presentation layer
    StrataCharter.Sim/               # engine-agnostic simulation core
    StrataCharter.Content/           # data definitions, schemas, loading helpers if needed
  tests/
    StrataCharter.Sim.Tests/
    StrataCharter.Content.Tests/     # only if content tooling becomes substantial
```

If the current repo differs, preserve the existing repo structure unless the task explicitly requests restructuring.

---

# 3. Architecture Standards

## 3.1 Separation of concerns

Prefer a clean, layered architecture:

### Simulation/domain layer
Responsible for:
- tiles, layers, and world data
- settlers and needs
- jobs, reservations, and work execution
- resources and inventories
- industry chains
- hazards and environmental simulation
- settlement cognition systems
- campaign state and settlement outcomes

This layer should:
- use plain C# types
- avoid Godot APIs
- be unit-testable without launching the engine
- expose state transitions through explicit methods, systems, or commands

### Application/orchestration layer
Responsible for:
- stepping the simulation
- coordinating systems in a deterministic order
- converting player commands into simulation commands
- persistence orchestration

### Presentation layer
Responsible for:
- Godot scenes and nodes
- rendering tilemaps, pawns, effects, and overlays
- UI interaction
- input translation into simulation commands
- audio and animation

## 3.2 Prefer composition over inheritance

Do not build deep inheritance trees for entities. Prefer:
- small focused classes
- component-like data composition when useful
- explicit systems operating over state

## 3.3 Determinism where practical

The game does not need lockstep multiplayer determinism right now, but core simulation should be predictable and testable.

Prefer:
- explicit random-number sources passed into systems
- stable tick/update ordering
- avoiding hidden time dependencies in the simulation core

## 3.4 Performance posture

Do not prematurely optimize, but avoid architecture that will obviously fail at colony scale.

Design with eventual support for:
- 40–80 active settlers in a mature settlement
- multiple z-layers
- job selection and pathfinding under changing map topology
- environmental propagation systems such as gas, heat, or structural instability

When implementing expensive systems, prefer:
- dirty-region updates
- event-driven invalidation
- caching where correctness is clear
- benchmarks only when performance is the subject of the task

---

# 4. Coding Standards

## 4.1 C# style

- Enable and respect nullable reference types.
- Use clear names over clever names.
- Prefer small methods with explicit purpose.
- Keep domain concepts named consistently with the design docs.
- Avoid introducing abbreviations unless already established.
- Prefer immutable value objects when reasonable, especially for coordinates, IDs, and commands.

## 4.2 Error handling

- Fail loudly for programmer errors and invalid impossible states.
- Use meaningful result types or exceptions where appropriate, rather than silent failure.
- Validate assumptions at boundaries.

## 4.3 Comments and documentation

Comments should explain:
- why a design choice exists
- assumptions that are not obvious from code
- nontrivial simulation edge cases

Do not write comments that merely restate the code.

For public or central simulation APIs, add XML documentation when it materially improves clarity.

---

# 5. Testing Standards

## 5.1 General rule

> New simulation behavior should usually come with automated tests.

The most important tests are unit tests for deterministic simulation logic.

## 5.2 Preferred test targets

Prioritize tests for:
- grid and z-layer coordinate logic
- pathfinding behavior
- job eligibility and job selection
- reservations and resource consumption
- production recipes
- settlement state transitions
- hazard propagation rules
- persistence serialization/deserialization if touched

## 5.3 Test style

- Tests should be readable and scenario-oriented.
- Prefer descriptive method names.
- Keep setup minimal and specific to the behavior under test.
- If a system is hard to test, refactor toward testability instead of skipping tests.

## 5.4 Godot-facing tests

Keep most logic outside Godot so that engine-dependent tests remain limited. Godot-side code may rely more on smoke checks or manual validation unless a dedicated testing harness is added.

---

# 6. Data and Content Guidance

The project should become increasingly data-driven over time.

Prefer external definitions for:
- buildings
- items
- recipes
- species profiles
- settlement charters
- doctrines
- hazards
- cognition technologies
- event definitions

Do not overbuild a content pipeline before the first systems need it. Implement enough structure to avoid hardcoding content directly into core simulation logic.

---

# 7. Design-Specific Engineering Rules

## 7.1 Layered world first
The game is fundamentally a layered colony simulation. Features should respect the z-layer model from the start where relevant.

## 7.2 Settlement-level roguelike logic
The primary roguelike build is the settlement, not individual pawns. Avoid implementing systems that overfocus on RPG-like pawn build complexity unless the task clearly asks for it.

## 7.3 Delegation/cognition is a core gameplay axis
Automation, advisory systems, and delegated cognition are not generic convenience features. They are part of the game’s central mechanical and narrative arc. Implementations should preserve a clear distinction between:
- deterministic rule automation
- advisory tools
- delegated decision systems
- synthetic cognition with risk implications

## 7.4 Long-term settlement persistence matters
Where applicable, systems should be designed with future campaign persistence in mind. A settlement may later be:
- chartered
- abstractly simulated
- revisited
- reclaimed as a ruin

Do not tightly couple important settlement history solely to transient UI state.

---

# 8. Development Priorities

Until the project reaches a vertical slice, prioritize proving the core game thesis in this order:

1. Layered grid and map rendering support.
2. Basic settler movement and pathfinding.
3. Job system: dig, haul, build.
4. Needs and survival pressure.
5. First industrial chain.
6. First vertical logistics mechanic.
7. First hazard/failure cascade.
8. First cognition/delegation mechanic.
9. First persistence stub for chartered or ruined settlement outcome.

Avoid expanding scope into elaborate lore UI, late-game tech trees, diplomacy webs, or polished combat before the settlement simulation loop is convincing.

---

# 9. Task Execution Expectations for Codex

For any implementation task:

1. Read the relevant docs and existing code before changing anything.
2. Make the smallest coherent change that solves the requested task.
3. Preserve existing architecture unless the task explicitly concerns refactoring.
4. Add or update tests when touching simulation logic.
5. Run the relevant build/test commands when available.
6. In the final response, clearly state:
   - what changed
   - why it changed
   - what was tested
   - any assumptions or follow-up risks

---

# 10. Do-Not Rules

- Do not put core simulation logic inside Godot scene scripts if it can reasonably live in `StrataCharter.Sim`.
- Do not introduce a new architecture pattern casually for one feature.
- Do not hardcode major game content into UI or engine-bound classes.
- Do not skip tests for central simulation behavior unless the task is purely exploratory or prototyping UI.
- Do not make pawn-level RPG complexity the main roguelike system by accident.
- Do not make convenience automation indistinguishable from dangerous cognition systems.
- Do not optimize prematurely at the expense of clarity, but do avoid obviously non-scaling approaches.

---

# 11. Suggested Initial Build Commands

These may be updated once the repo exists.

```bash
dotnet build
dotnet test
```

If the Godot project structure adds custom commands later, update this section.


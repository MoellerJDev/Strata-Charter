# Strata Charter: Technical Architecture

Version: 0.1  
Status: Initial engineering direction

## 1. Purpose

This document defines the initial technical direction for **Strata Charter**.

It is intended for human developers and Codex agents working in the repository. The goal is to keep implementation consistent as the project moves from design into a playable prototype.

The companion design document is:

- `docs/GAME_DESIGN.md`

The implementation guidance document for coding agents is:

- `AGENTS.md`

## 2. Technical Goals

The project must support:

- A tile-based, layered z-level world.
- Isometric presentation.
- Settler movement, jobs, hauling, building, and needs.
- Settlement-scale simulation with a mature target of 40 to 80 active settlers.
- Long-running settlements with persistent history.
- Chartered or ruined settlements that survive in the campaign layer.
- Data-driven content for species, buildings, recipes, doctrines, hazards, and events.
- Testable core simulation logic outside the game engine.

The most important architectural decision is:

> The simulation core must not depend on Godot.

Godot should render and interact with the simulation. It should not own the simulation model.

## 3. Engine and Language

### 3.1 Recommended Engine

Use **Godot 4.6+ .NET edition**.

### 3.2 Language

Use **C# / .NET 8+**.

### 3.3 Initial Platform Target

Desktop first.

The game should not initially optimize for mobile, console, or web. The simulation complexity and UI density are better suited to desktop.

### 3.4 Why Godot

Godot is a strong fit because the game is primarily:

- 2D/isometric.
- Simulation-heavy.
- UI-heavy.
- Tile/layer based.
- Better served by custom domain architecture than by advanced 3D engine features.

Unity remains a viable fallback, but the current repo direction should assume Godot unless explicitly changed.

## 4. Repository Structure

Recommended initial structure:

```text
/
  AGENTS.md
  README.md
  docs/
    GAME_DESIGN.md
    TECHNICAL_ARCHITECTURE.md
    ADRs/
  src/
    StrataCharter.Game/
    StrataCharter.Sim/
    StrataCharter.Content/
  tests/
    StrataCharter.Sim.Tests/
    StrataCharter.Content.Tests/
```

### 4.1 `StrataCharter.Game`

Godot project and presentation layer.

Responsibilities:

- Godot scenes and nodes.
- Tile rendering.
- Pawn rendering.
- Camera and layer controls.
- UI.
- Input handling.
- Audio.
- Animation hooks.
- Debug visualization.

This project may reference `StrataCharter.Sim` and `StrataCharter.Content`.

### 4.2 `StrataCharter.Sim`

Engine-agnostic simulation core.

Responsibilities:

- World grid and z-layer data.
- Tile state.
- Entities and settlers.
- Needs.
- Jobs and reservations.
- Pathfinding.
- Inventory/resource model.
- Production and recipes.
- Construction and excavation.
- Hazards.
- Settlement cognition systems.
- Settlement outcome summaries.
- Campaign state models.

This project must not reference Godot APIs.

### 4.3 `StrataCharter.Content`

Content loading, validation, and schemas.

Responsibilities may include:

- Loading JSON/YAML/TOML definitions.
- Validating item/building/species/recipe data.
- Providing typed content registries to the simulation.

This project should avoid becoming a second simulation layer.

### 4.4 `tests/`

Automated tests, especially for simulation behavior.

Simulation logic should usually be testable without launching Godot.

## 5. Layered Architecture

### 5.1 Domain Layer

The domain layer contains the game state and business rules.

Examples:

- `WorldGrid`
- `Tile`
- `LayerIndex`
- `MapPosition`
- `Settler`
- `NeedState`
- `Job`
- `Inventory`
- `Recipe`
- `SettlementState`

Rules:

- Plain C#.
- No Godot dependencies.
- Prefer explicit state transitions.
- Prefer simple data structures over engine-bound objects.

### 5.2 Simulation Systems Layer

Systems operate on domain state.

Examples:

- `NeedSystem`
- `JobAssignmentSystem`
- `MovementSystem`
- `PathfindingService`
- `HaulingSystem`
- `ConstructionSystem`
- `ProductionSystem`
- `HazardSystem`
- `CognitionSystem`

Rules:

- Systems should have narrow responsibilities.
- Systems should be testable.
- Systems should avoid hidden global state.
- Randomness should be injected or explicitly owned by the simulation context.

### 5.3 Application/Orchestration Layer

Coordinates simulation ticks and player commands.

Responsibilities:

- Step the simulation at a fixed tick rate.
- Apply player commands.
- Queue and dispatch simulation events.
- Coordinate save/load operations.
- Convert settlement outcomes into campaign results.

### 5.4 Presentation Layer

Godot-facing layer.

Responsibilities:

- Render simulation state.
- Translate input into simulation commands.
- Display UI and debug overlays.
- Animate state changes.

Rules:

- Do not duplicate simulation logic in Godot scripts.
- Do not let Godot node hierarchy become the authoritative game state.
- Treat Godot objects as views/controllers over simulation state.

## 6. Simulation Tick Model

### 6.1 Fixed Tick

The simulation should advance in fixed ticks independent of rendering framerate.

Recommended early approach:

- Godot frame update accumulates elapsed time.
- Simulation advances zero or more fixed ticks per frame.
- Rendering reads the latest simulation state.

### 6.2 Simulation Speed

The architecture should support:

- Pause.
- Normal speed.
- Fast speed.
- Possibly very fast debug speed.

### 6.3 Tick Ordering

System update ordering should be explicit.

A possible early tick order:

1. Apply queued player commands.
2. Update needs.
3. Resolve job eligibility and reservations.
4. Assign jobs.
5. Move settlers.
6. Execute job work.
7. Update production.
8. Update hazards/environment.
9. Emit events and notifications.
10. Check win/fail/charter conditions.

This order will change, but it should remain explicit.

## 7. World Model

### 7.1 Coordinates

Use a value object for map positions.

Conceptually:

```csharp
public readonly record struct MapPosition(int X, int Y, int Z);
```

The z value represents a discrete layer.

### 7.2 Grid

The world is a layered tile grid.

Core concepts:

- Width and height per layer.
- Multiple z-layers.
- Tile type.
- Occupancy.
- Walkability.
- Structural state.
- Hazard state.
- Room/region data later.

### 7.3 Tile Data

A tile should initially represent enough information to support:

- Whether it is solid or open.
- Whether it can be walked on.
- Whether it can be mined.
- Whether it contains a constructed floor/wall/object.
- Whether it contains hazards such as gas, heat, or instability.

Do not overbuild tile complexity before pathfinding, digging, and construction are working.

### 7.4 Vertical Connectivity

Vertical movement should be explicit through connectors:

- Stairs.
- Ladders.
- Ramps.
- Lift shafts.
- Freight lifts.

A path from `(x, y, z)` to `(x, y, z + 1)` should require an appropriate connector or traversal rule.

## 8. Pathfinding

### 8.1 Initial Approach

Use A* over the layered grid.

Nodes are walkable tile positions. Edges connect:

- Cardinal neighbors on the same z-layer.
- Vertical neighbors through connectors.

Diagonal movement should be a deliberate design decision. Start without diagonals unless the design requires them.

### 8.2 Cost Model

Path cost can eventually include:

- Distance.
- Doors.
- Stairs/ladders/lifts.
- Hazard exposure.
- Zone restrictions.
- Species-specific movement modifiers.
- Congestion.

For the first prototype, keep costs simple.

### 8.3 Invalidation

Changing tiles should invalidate relevant path data.

Early implementation can recompute paths on demand. Later systems should consider:

- Dirty regions.
- Cached walkability maps.
- Region graphs.
- Separate high-level and low-level pathfinding.

### 8.4 Testing

Pathfinding must have unit tests for:

- Same-layer navigation.
- Blocked tiles.
- Vertical connectors.
- No-path cases.
- Recomputed paths after excavation or construction.

## 9. Entity and Settler Model

### 9.1 Entity IDs

Use stable IDs for entities.

Do not rely on Godot node references as identity.

Examples:

```csharp
public readonly record struct EntityId(Guid Value);
public readonly record struct SettlerId(Guid Value);
```

A simpler integer allocator is also acceptable early if saves and deterministic tests are considered.

### 9.2 Settlers

A settler should initially include:

- ID.
- Name.
- Species.
- Position.
- Needs.
- Skills or role weights.
- Current job.
- Job priorities.
- Health/status flags.

Avoid overbuilding social simulation before the work loop is fun.

### 9.3 Needs

MVP needs:

- Hunger.
- Rest.
- Exposure/temperature.
- Morale/stress.

Needs should update deterministically and produce job desires or status effects.

### 9.4 Story-Significant Individuals

The simulation should eventually mark some settlers as historically significant:

- Founders.
- Operators.
- Crisis survivors.
- Faction leaders.
- Notable dead.

This can begin as metadata on events rather than a full narrative system.

## 10. Job System

### 10.1 Job Types

MVP job types:

- Dig/mine.
- Haul.
- Build.
- Repair.
- Eat.
- Sleep.
- Operate workstation.
- Refuel or supply machine.

### 10.2 Job Lifecycle

A job should move through clear states:

1. Available.
2. Reserved.
3. In progress.
4. Completed.
5. Failed/cancelled.

### 10.3 Reservations

Reservations prevent multiple settlers from trying to consume or manipulate the same target incorrectly.

Reserveable objects may include:

- Job targets.
- Items or stacks.
- Workstations.
- Destination tiles.

Start simple, but do not ignore reservations entirely. Colony sims become unstable without them.

### 10.4 Job Selection

Initial selection can be priority-based.

Inputs:

- Settler role priorities.
- Distance.
- Job urgency.
- Skill suitability.
- Safety.
- Zone permissions.

Do not prematurely build a complex utility AI if simple priority logic proves enough for the prototype.

### 10.5 Testing

Job tests should cover:

- Eligibility.
- Priority ordering.
- Reservation behavior.
- Job cancellation.
- Resource consumption.
- Failure when target becomes unreachable.

## 11. Resources, Inventory, and Production

### 11.1 Initial Resource Model

Start with a simple item stack model.

MVP resources:

- Food/rations.
- Scrap.
- Ore.
- Refined material/plates.
- Structural components.
- Fuel.

### 11.2 Stockpiles

Stockpiles should support:

- Allowed item categories.
- Priority.
- Capacity.
- Hauling jobs.

### 11.3 Production Recipes

Recipes should be data-driven as early as practical.

A recipe includes:

- Input items.
- Output items.
- Work amount.
- Required workstation.
- Optional skill modifiers.

### 11.4 First Production Chain

Prototype chain:

1. Mine ore.
2. Haul ore to primitive furnace.
3. Process ore into plates.
4. Use plates to build structural components.
5. Use structural components for vertical infrastructure.

## 12. Construction and Excavation

### 12.1 Designations

The player issues designations, not direct commands to individual settlers.

Examples:

- Mine tile.
- Build wall.
- Build floor.
- Build stair/lift.
- Deconstruct.
- Repair.

### 12.2 Blueprints

Buildings should exist as planned blueprints before construction completes.

A blueprint should track:

- Required resources.
- Required work.
- Build location.
- Blocking conditions.
- Completion state.

### 12.3 Excavation

Mining a solid tile should:

- Validate mineability.
- Generate a job.
- Change tile state on completion.
- Possibly spawn resources.
- Possibly affect structural stability or hazards.

## 13. Hazards and Environment

### 13.1 MVP Hazards

Start with one or two:

- Cave-in/structural instability.
- Gas pocket or toxic gas.
- Surface cold/storm exposure.

### 13.2 Hazard Philosophy

Hazards should create readable cascades, not random punishment.

The player should be able to understand:

- What went wrong.
- What infrastructure was missing.
- What decision increased the risk.
- How the next settlement might prepare differently.

### 13.3 Propagation Systems

Gas, heat, fluid, and structural risk can become expensive systems.

Early guidance:

- Use simple local propagation.
- Update only relevant/dirty regions where practical.
- Prefer debuggable behavior over realism.
- Add overlays early.

## 14. Cognition and Delegation Systems

### 14.1 Design Importance

Cognition is a core gameplay axis, not just lore.

The architecture should make room for systems that:

- Reduce micromanagement.
- Modify job assignment or production policy.
- Introduce settlement-level risk.
- Leave persistent legacy traits.

### 14.2 System Categories

#### Rule Automation

Deterministic, safe systems.

Examples:

- Stockpile targets.
- Pump thresholds.
- Auto-refuel rules.

#### Advisory Engines

Suggest actions but do not execute broad policies.

Examples:

- Shortage forecast.
- Collapse risk warning.
- Staffing recommendation.

#### Delegated Cognition

Executes policy within bounded authority.

Examples:

- District labor manager.
- Dynamic production balancer.
- Emergency hazard controller.

#### Integrated Cognition

High-risk systems that coordinate across domains and may trigger noetic exposure.

Examples:

- Settlement planning engine.
- Cross-district optimizer.
- Autonomous crisis strategist.

### 14.3 Implementation Guidance

Do not hardcode cognition systems as UI shortcuts.

They should modify simulation behavior through clear interfaces, such as:

- Policy objects.
- Job scoring modifiers.
- Production queue controllers.
- Hazard response controllers.
- Event emitters.

### 14.4 Noetic Exposure

Initial noetic exposure can be a simple settlement-level value or state enum, but the design should not expose it as a plain “evil meter” by default.

It should drive events, strange recommendations, faction reactions, and persistent legacy traits.

## 15. Campaign Persistence

### 15.1 Settlement Outcomes

At minimum, a completed settlement should produce an outcome summary:

- Settlement name.
- Location/site identity.
- Population status.
- Major species composition.
- Industrial role.
- Cognition architecture.
- Major factions affected.
- Cause of success or failure.
- Legacy traits.

### 15.2 Chartered Settlement

A successful settlement becomes a campaign node.

Tracked abstract state:

- Population.
- Exports.
- Imports.
- Stability.
- Risk level.
- Faction alignment.
- Cognition risk.
- Notable founding history.

### 15.3 Ruined Settlement

A failed settlement becomes a ruin node.

Tracked abstract state:

- Ruin cause.
- Surviving hazards.
- Salvage value.
- Reclamation difficulty.
- Noetic contamination, if any.
- Snapshot reference for future revisit.

### 15.4 Save Strategy

Early saves can be JSON for readability and debugging.

Later, consider:

- Compressed JSON.
- Binary serialization.
- Versioned save migrations.

Do not build elaborate save infrastructure before the core simulation stabilizes, but do keep save compatibility in mind.

## 16. Content Pipeline

### 16.1 Data-Driven Definitions

Content should become data-driven over time.

Good candidates:

- Items.
- Buildings.
- Recipes.
- Species.
- Needs.
- Charters.
- Doctrines.
- Factions.
- Hazards.
- Events.
- Cognition technologies.

### 16.2 Format

Use JSON initially unless the project develops a strong reason to use YAML, TOML, or custom resources.

### 16.3 Validation

Content loading should validate required fields and references.

Bad content should fail loudly during development.

## 17. UI and Debugging Tools

### 17.1 Required Debug Overlays

Build debug tools early.

Minimum useful overlays:

- Walkability.
- Pathfinding result.
- Job targets.
- Reservations.
- Tile solidity/open space.
- Structural risk.
- Hazard presence.
- Settler current job.

### 17.2 Explainability

Colony sims require explainability.

The UI should eventually answer:

- Why is this settler idle?
- Why is this job not being done?
- Why is this tile unreachable?
- Why did this production chain stop?
- Why is this settler stressed?
- Why did this cognition system recommend this?

Do not wait until late development to add diagnostic UI.

## 18. Testing Strategy

### 18.1 Test Priority

Simulation logic should usually have automated tests.

Highest priority test areas:

- Coordinate and layer logic.
- Grid mutation.
- Pathfinding.
- Job eligibility.
- Reservations.
- Resource consumption.
- Production recipes.
- Needs ticking.
- Hazard propagation.
- Settlement outcome generation.

### 18.2 Unit Tests

Use unit tests for deterministic systems.

Test examples:

- A settler can path to a job on the same layer.
- A settler cannot path through solid rock.
- A stair connects two layers.
- A mine designation creates a valid job.
- Two settlers do not reserve the same item stack incorrectly.
- A recipe consumes the correct input and produces the correct output.

### 18.3 Integration Tests

Add integration tests for multi-system behavior when useful.

Example:

- Mine ore, haul ore, process ore into plates, then build a structure.

### 18.4 Godot Tests

Keep Godot-specific tests limited initially. Most behavior should be tested in `StrataCharter.Sim`.

Use manual validation or smoke tests for rendering and UI until a Godot test harness is worth the cost.

## 19. Coding Standards

### 19.1 C# Standards

- Enable nullable reference types.
- Use clear names.
- Prefer small methods.
- Prefer immutable value objects for IDs, coordinates, and commands.
- Avoid hidden global state.
- Avoid God objects.

### 19.2 Error Handling

- Fail loudly for invalid impossible states.
- Validate public boundaries.
- Use explicit result types where failure is expected and recoverable.
- Use exceptions for programmer errors and invariant violations.

### 19.3 Comments

Comments should explain why, not what.

Good comments:

- Non-obvious simulation assumptions.
- Performance tradeoffs.
- Future design hooks.
- Edge cases.

Bad comments:

- Restating a method name.
- Explaining obvious control flow.

## 20. MVP Implementation Order

Recommended first implementation sequence:

1. Create solution and project structure.
2. Create `MapPosition` and layered grid primitives.
3. Add tile solidity and walkability.
4. Add simple map generation for surface plus underground layers.
5. Add same-layer pathfinding.
6. Add vertical connectors and cross-layer pathfinding.
7. Add settlers with positions and movement.
8. Add designations and basic jobs.
9. Add dig jobs that mutate the map.
10. Add haul/build loop.
11. Add simple needs.
12. Add first production chain.
13. Add first hazard.
14. Add first cognition/delegation prototype.
15. Add settlement outcome persistence stub.

## 21. Architecture Decision Records

Use ADRs for major decisions once the repo stabilizes.

Recommended ADRs:

- ADR-001: Engine and language choice.
- ADR-002: Simulation core separated from Godot.
- ADR-003: Layered grid world model.
- ADR-004: Initial save format.
- ADR-005: Pathfinding approach.

ADRs should be short and practical.

## 22. Known Risks

### 22.1 Scope Risk

The concept combines colony simulation, persistent campaign, multiple species, layered maps, and AI/cognition systems. The MVP must stay narrow.

### 22.2 Simulation Complexity

Job systems, pathfinding, reservations, hazards, and needs can interact unpredictably. Prioritize debug tools and tests early.

### 22.3 UI Complexity

A 40 to 80 settler colony across multiple z-layers needs excellent UI. Do not wait until late development to solve layer visibility, idle settler explanations, and job diagnostics.

### 22.4 Performance

Pathfinding and job selection can become expensive. Keep architecture ready for caching and dirty-region updates, but do not over-optimize before profiling.

### 22.5 Lore/System Integration

Cognition systems are central to the game. If implemented as ordinary automation bonuses, the project loses a key identity. Keep the distinction between rule automation, advisory systems, delegated cognition, and dangerous integrated cognition clear in code and UI.

## 23. Near-Term Engineering Definition of Done

For early Codex/development tasks, a change is done when:

- It compiles.
- Relevant tests pass or a clear reason is given.
- Simulation logic is not placed in Godot scripts unless unavoidable.
- New domain behavior has tests when practical.
- Assumptions are documented in code comments, tests, or the final task summary.
- The implementation remains consistent with `GAME_DESIGN.md` and `AGENTS.md`.

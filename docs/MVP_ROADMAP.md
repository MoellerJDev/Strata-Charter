# Strata Charter: MVP Roadmap

Version: 0.1  
Status: Initial implementation roadmap

## 1. Purpose

This document defines the recommended path from repository setup to the first playable proof of concept for **Strata Charter**.

It is intended to keep development focused on proving the core thesis before the project expands into broad campaign systems, deep lore implementation, or polished production content.

Companion documents:

- `AGENTS.md`
- `docs/GAME_DESIGN.md`
- `docs/TECHNICAL_ARCHITECTURE.md`

## 2. MVP Thesis

The MVP should prove this:

> A layered settlement can grow from a vulnerable frontier camp into an early industrial outpost, generate compelling logistical and environmental pressure, make one meaningful cognition/delegation choice, and leave behind a persistent outcome that could matter to a future campaign.

The MVP does **not** need to prove the entire long-form vision. It needs to prove that the foundation is fun, legible, and technically sound.

## 3. MVP Design Targets

### 3.1 Target Player Experience

By the end of the MVP scenario, the player should have experienced:

- Landing with a small expedition and inadequate supplies.
- Establishing first shelter against environmental pressure.
- Digging into layered terrain.
- Building a small but meaningful industrial loop.
- Managing settler labor through a job system.
- Solving a vertical logistics problem.
- Responding to at least one failure cascade or serious hazard.
- Making one cognition-related decision that meaningfully changes colony management.
- Reaching either a charter-ready outcome or a ruin/failure outcome.

### 3.2 Target Settlement Scale

For MVP:

- Starting settlers: **6**
- Expected successful settlement population: **12 to 20**
- Stretch target: **25**
- Layers: **surface + 3 underground layers**
- Session target for a successful MVP scenario: **60 to 120 minutes**

The final game may target longer 8–15 hour settlement arcs, but the MVP should compress the core dramatic arc enough to validate it quickly.

## 4. MVP Scope

## 4.1 Included Systems

### World and Terrain

- Tile-based layered world.
- Discrete z-levels.
- Procedural or seeded test map generation.
- Surface terrain and three underground strata.
- Diggable tiles.
- Buildable floor and wall tiles.
- Vertical connections through stairs or shaft/lift prototypes.
- Basic tile occupancy and walkability rules.

### Camera and Visualization

- Isometric presentation.
- Fixed initial camera orientation.
- Layer selection controls.
- Visual emphasis for the active layer.
- Basic ghosting or concealment for non-active layers.
- Debug overlays for walkability, selected layer, path preview, and job targets.

### Settlers

- 6 starting settlers.
- Position, movement, and pathfinding.
- Basic needs:
  - hunger
  - rest
  - exposure/temperature
  - morale or stress
- Basic skill or aptitude differentiation, lightweight only.
- Death/incapacitation state if needs collapse or hazards overwhelm them.

### Job System

- Job discovery and assignment.
- Reservations so settlers do not duplicate the same work incorrectly.
- Core job types:
  - move
  - mine tile
  - haul item
  - construct blueprint
  - operate workbench/furnace
  - rest
  - eat
  - repair simple damaged object
- Basic work priorities or role preferences.

### Items and Resources

- Loose items in the world.
- Stockpile zones.
- Simple inventory carrying.
- Resource types:
  - salvage scrap
  - raw ore
  - refined metal plates
  - food rations
  - fuel or energy cells
  - structural components
- Item stacks where practical.

### Construction

- Blueprints.
- Build completion requirements.
- Core structures:
  - wall
  - floor
  - door
  - bed/cot
  - heater or shelter-support device
  - stockpile marker
  - primitive furnace/refinery
  - basic workbench
  - stairway or primitive vertical connector
  - freight lift or powered vertical transfer prototype
  - charter relay/beacon

### Industry

One complete progression chain:

1. Scavenge salvage and mine ore.
2. Refine ore into metal plates.
3. Use metal plates for better structures and vertical logistics.
4. Produce structural components required for the charter objective or deeper extraction.

Optional if feasible:

- Fuel consumption for the furnace.
- Workbench recipe queues.
- Simple stock targets.

### Survival Pressure

At least two forms of pressure:

1. **Environmental exposure**
   - Surface cold, heat, or storms.
   - Sheltered interiors reduce or eliminate pressure.

2. **Subsurface hazard**
   - Cave-in risk, gas pocket, or unstable terrain.
   - Must be visible enough to learn from.
   - Must be able to trigger a failure cascade if ignored.

### Cognition / Delegation

At least one meaningful cognition progression choice.

Recommended MVP implementation:

#### Bounded Automation
The player can unlock a deterministic rule system such as:

- stock target automation for a furnace or workbench
- automatic refueling threshold
- automated lift dispatch rules

#### Delegated Cognition Choice
Later in the MVP scenario, the player encounters a more powerful system:

- a discovered logistics cognition relic
- a semi-legal advisory engine
- a colony planning construct

It offers a real gameplay benefit, such as:

- reducing hauling inefficiency
- dynamically assigning settlers to high-priority resource flow
- identifying looming shortages
- improving vertical freight usage

The player should choose between:

- using it and accepting an explicit risk flag or political consequence
- refusing it and keeping the colony more manual but safer or more compliant

The MVP does not need a full noetic-event chain. It needs to prove that the delegation choice is mechanically desirable and narratively charged.

### Faction Pressure

Include one external pressure mechanic in minimal form.

Recommended MVP version:

- A faction or local authority objects to either:
  - deep extraction,
  - disturbance of a cavern ecology,
  - or activation of the cognition relic.

This can be represented through:

- an event prompt,
- a relation meter,
- or a single conditional consequence.

The goal is not full diplomacy. The goal is to show that colony decisions have social and campaign implications beyond immediate efficiency.

### Settlement Outcome and Persistence Stub

At scenario completion, the settlement becomes one of:

#### Charter Outcome
The colony survives and reaches the charter threshold.

Record:
- settlement name
- result type
- major objective completed
- whether cognition tech was activated
- basic output specialization
- founder survival count
- key losses

#### Ruin Outcome
The colony collapses or the player fails the objective.

Record:
- ruin name
- cause of failure
- settlement depth reached
- remaining strategic asset, if any
- whether the cognition relic was activated
- survivor count, if applicable

The persistence stub can be JSON written locally. It does not need to power a fully interactive campaign map yet.

---

## 5. MVP Non-Goals

The MVP should explicitly avoid:

- Full persistent planetary campaign.
- Full multi-settlement world simulation.
- Revisit and reclamation gameplay.
- More than one meaningful faction system.
- Deep diplomacy.
- Full combat model.
- Large military systems.
- Extensive procedural storytelling.
- Complete species roster.
- Final art, animation, sound, or UI polish.
- 40–80 pawn settlement scaling.
- Late-game noetic catastrophe systems.
- Full offscreen AI governance simulation for chartered colonies.
- Robust save/load beyond what is needed for iteration, unless save/load is the task.

These belong after the core loop is validated.

---

# 6. Proposed MVP Scenario

## 6.1 Working Scenario: Cold Ridge Charter

A six-person frontier expedition is dropped onto a hostile mineral ridge. Surface conditions are survivable only temporarily. The expedition must establish shelter, descend into a resource-bearing subsurface layer, refine structural materials, and activate a charter relay before supplies and hazards overwhelm them.

### Scenario Arc

#### Act 1: Landfall
- Settlers arrive with:
  - limited food
  - scrap
  - a few heaters or emergency modules
  - basic hand tools
- The player must:
  - place stockpile areas
  - designate first excavation or shelter construction
  - manage exposure and sleep

#### Act 2: First Burrow
- The settlement moves partially underground.
- Basic industry unlocks:
  - furnace
  - workbench
  - simple extraction chain
- The player starts to feel labor bottlenecks.

#### Act 3: Descent
- The player pushes into a deeper layer.
- A hazard appears:
  - gas pocket,
  - cave-in threat,
  - or unstable heat fissure.
- Vertical logistics become relevant.

#### Act 4: The Cognition Choice
- A buried or dropped system becomes available.
- It can:
  - improve logistics allocation,
  - forecast material bottlenecks,
  - or control vertical freight more efficiently.
- A factional or legal warning appears.
- The player chooses whether to integrate it.

#### Act 5: Charter or Collapse
- The player must complete the charter beacon/relay.
- To succeed, they need:
  - specific refined materials,
  - stable shelter,
  - minimum survivors,
  - and a functioning path to the build site.
- Outcome is summarized and saved as a campaign stub.

---

# 7. Development Milestones

## Milestone 0: Repository and Build Foundation

### Goal
Create a clean repo structure that supports the project architecture.

### Deliverables
- Godot 4.6+ .NET project scaffold.
- `StrataCharter.Sim` class library.
- `StrataCharter.Content` class library or placeholder.
- Test project for simulation core.
- CI-friendly build/test commands.
- Basic README run instructions.

### Definition of Done
- `dotnet build` succeeds.
- `dotnet test` succeeds.
- Godot project opens without errors.
- A blank or placeholder test scene runs.

---

## Milestone 1: Layered Grid Model

### Goal
Prove the simulation can represent and render a layered settlement map.

### Deliverables
- Coordinate types:
  - 2D tile coordinate
  - z-level coordinate or unified 3D grid coordinate
- Tile data model.
- Chunk or map container abstraction.
- Tile walkability and solidity.
- Surface plus multiple underground layers.
- Basic generated test map.
- Godot rendering bridge for tiles.
- Layer selector UI or debug controls.

### Definition of Done
- Developer can switch among visible layers.
- Diggable vs solid vs open tiles are represented correctly.
- Map state lives in simulation code, not Godot scene state.
- Tests cover coordinate logic and tile querying.

---

## Milestone 2: Settler Movement and Pathfinding

### Goal
Prove settlers can navigate layered terrain.

### Deliverables
- Settler entity model.
- Movement system.
- Same-layer pathfinding.
- Vertical connector support, if included here rather than Milestone 4.
- Click/debug move command for testing.
- Basic settler rendering.

### Definition of Done
- Settlers can move to reachable destinations.
- Unreachable destinations fail cleanly.
- Pathfinding does not require Godot APIs.
- Tests cover simple reachable, blocked, and multi-step paths.

---

## Milestone 3: Jobs, Reservations, and Work Execution

### Goal
Build the first real simulation loop.

### Deliverables
- Job abstraction.
- Job provider or job discovery mechanism.
- Reservation system.
- Work executor state.
- Basic jobs:
  - mine
  - haul
  - construct
- Player designations:
  - mining designation
  - building blueprint designation
- Settlers autonomously choose and complete eligible work.

### Definition of Done
- Designating mine tiles causes settlers to mine them.
- Mined outputs appear as items.
- Designating a blueprint causes settlers to haul required resources and construct it.
- Two settlers do not permanently fight over the same reserved task.
- Tests cover core job lifecycle and reservation behavior.

---

## Milestone 4: Items, Stockpiles, and First Industrial Chain

### Goal
Create a small economy that starts feeling like a colony sim.

### Deliverables
- Item entities and stacks.
- Settler carrying.
- Stockpile zones.
- Furnace or refinery building.
- Recipe model.
- Ore → plates production chain.
- Workbench or structural component recipe.
- Basic UI to issue or inspect production targets.

### Definition of Done
- Ore can be mined, hauled, refined, and used to build higher-tier structures.
- Stockpiles influence where goods end up.
- Industry requires labor and resources rather than creating outputs instantly.
- Tests cover recipe consumption and production output.

---

## Milestone 5: Survival Needs and Shelter

### Goal
Make the opening feel vulnerable and meaningful.

### Deliverables
- Hunger need.
- Rest need.
- Exposure or temperature pressure.
- Beds/cots.
- Food/ration consumption.
- Simple shelter recognition or interior safety proxy.
- Initial fail state from neglect.

### Definition of Done
- Settlers become less effective or incapacitated when needs collapse.
- Interior shelter improves survival meaningfully.
- The first 10–20 minutes of the MVP scenario involve real survival tradeoffs.
- Tests cover need decay and basic recovery.

---

## Milestone 6: Vertical Logistics and Deeper Progression

### Goal
Make depth mechanically distinct and foundational.

### Deliverables
- Vertical movement through stairs, shaft, or lift.
- First deeper resource source.
- Freight or transfer constraint across layers.
- One objective that requires deeper materials.

### Definition of Done
- Lower layers are not decorative; they are necessary for progression.
- The player experiences a real logistics problem caused by depth.
- Pathfinding and jobs work across layers.
- Tests cover vertical reachability and cross-layer work where feasible.

---

## Milestone 7: Hazard and Failure Cascade

### Goal
Prove that the game can generate memorable systemic danger.

### Deliverables
Choose one strong hazard first:
- cave-in,
- gas pocket,
- or unstable heat vent.

Include:
- hazard detection or visible warning state
- hazard spread or event resolution
- damage or blocked accessibility
- interaction with existing infrastructure

### Definition of Done
- Ignoring the hazard can produce a serious colony setback.
- Preparing for or reacting to the hazard can save the settlement.
- The failure is readable after the fact.
- Debug tools allow developers to inspect hazard state.

---

## Milestone 8: Cognition / Delegation Prototype

### Goal
Prove the central AI temptation works as gameplay.

### Deliverables
- One safe bounded automation feature.
- One higher-risk delegated cognition feature.
- One event or decision point that gates its activation.
- One visible benefit from activation.
- One recorded consequence flag in settlement outcome.

### Definition of Done
- The player has a real reason to want the cognition system.
- Choosing it changes settlement management, not just a percentage stat.
- Refusing it is viable but more laborious or less efficient.
- Outcome summary records the decision.

---

## Milestone 9: Faction Pressure and Outcome Resolution

### Goal
Connect colony choices to the larger setting.

### Deliverables
- One faction or authority response event.
- One consequence tied to:
  - deep extraction,
  - cognition activation,
  - or both.
- Charter success condition.
- Ruin/failure condition.
- End-of-scenario summary.
- Persistence stub written locally.

### Definition of Done
- The MVP scenario can end with a meaningful success or failure summary.
- The summary includes at least:
  - founder/survivor count
  - depth reached
  - cognition choice
  - major failure or success reason
  - chartered or ruined result
- Output data can plausibly feed a future planetary campaign layer.

---

## Milestone 10: Playtest and Revision Pass

### Goal
Determine whether the MVP proves the project thesis.

### Evaluation Questions
- Is layered excavation actually satisfying?
- Does the settlement opening feel tense rather than slow?
- Does the first industry chain create interesting planning?
- Does vertical logistics create depth or just hassle?
- Is the cognition/delegation choice genuinely tempting?
- Does the hazard feel like a readable story rather than random punishment?
- Does the settlement outcome make the player want to found another one?

### Deliverables
- Internal playtest notes.
- Prioritized issue list.
- First balancing pass.
- Recommendation:
  - proceed into vertical slice,
  - revise core loop,
  - or simplify/re-scope.

---

# 8. Suggested Initial Codex Task Sequence

These are intentionally small and repo-friendly. They are suitable as early Codex prompts once the repo exists.

## Task 1
Scaffold the repo structure from `AGENTS.md` and `TECHNICAL_ARCHITECTURE.md`.

## Task 2
Create simulation coordinate primitives for layered grid positions, with tests.

## Task 3
Implement a minimal tile grid that supports multiple z-levels and tile querying, with tests.

## Task 4
Expose a generated test map from `StrataCharter.Sim` and render it in Godot.

## Task 5
Add layer switching in the Godot presentation layer without moving simulation ownership into Godot.

## Task 6
Implement settler position and basic same-layer A* pathfinding in the simulation project, with tests.

## Task 7
Render a settler and add a debug move command that sends a simulation command.

## Task 8
Implement dig designations and a basic mining job lifecycle.

## Task 9
Implement mined item spawning, hauling, and a stockpile zone.

## Task 10
Implement blueprint construction for walls or floors.

These early tasks intentionally stop before deeper systems so the architecture can be corrected while the cost of change is low.

---

# 9. Acceptance Criteria for Declaring the MVP Successful

The MVP is successful when:

1. A player can run a complete scenario from landfall to charter/failure.
2. The settlement begins vulnerable and becomes meaningfully more capable.
3. Digging downward creates real strategic value.
4. Industry produces at least one satisfying dependency chain.
5. Settlers autonomously execute jobs and the player plans around labor constraints.
6. A hazard can create a memorable but understandable failure.
7. A cognition/delegation choice meaningfully changes play.
8. The scenario ending produces a persistence-ready settlement or ruin summary.
9. The codebase remains aligned with the architecture:
   - simulation core outside Godot
   - tests for core logic
   - no foundational systems trapped in UI scripts

---

# 10. What Comes After the MVP

If the MVP succeeds, the next phase should move toward a **vertical slice**, not immediately toward full production.

Recommended next expansion areas:

- Better visual identity and art pipeline.
- Second species implementation to validate asymmetrical population simulation.
- Richer doctrine or settlement-build choices.
- More meaningful cognition tree.
- A lightweight planetary map prototype.
- Chartered colony abstractions.
- Ruin/revisit foundation.
- One stronger faction relationship arc.
- Save/load robust enough for multi-session play.

The central question after the MVP is:

> Does Strata Charter deserve to become a full game because the colony loop, depth progression, and cognition temptation are already compelling in miniature?

If yes, then expand the campaign. If not, fix the colony loop before adding breadth.

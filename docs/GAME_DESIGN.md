# Strata Charter: Game Design Document

Version: 0.2  
Status: Pre-production design draft

## 1. High Concept

**Strata Charter** is a persistent-world, layered colony roguelite set in a mythic industrial science-fantasy universe.

The player directs successive frontier settlements on a hostile, resource-rich planet. Each settlement begins as a desperate expeditionary camp, grows into a complex industrial colony, and eventually becomes one of three things:

- A chartered colony that persists under AI governance and shapes future expeditions.
- A troubled mature settlement that the player keeps directly stewarding for greater reward and greater risk.
- A ruin, disaster site, or contested scar in the planetary campaign.

The planet, its settlements, its losses, and its discoveries persist across the campaign. A failed colony is not deleted history. It becomes future history.

## 2. Core Thesis

The game is about building settlements that become too large and complex for direct human-scale control.

At first, the player knows every colonist, every job, and every supply shortage. As a settlement grows, it develops industry, districts, vertical infrastructure, competing species needs, political pressures, and emergency systems. The player is then tempted to adopt increasingly powerful cognition tools that can manage parts of the colony for them.

The central tension is:

> Civilization expands by building systems too large for individuals to manage, but in this universe, sufficiently complex synthetic minds draw the attention of a cosmic entity that treats artificial consciousness as an ecological violation.

Every settlement naturally wants more coordination, more delegation, more optimization, and more cognition. The player feels that temptation mechanically as settlements scale.

The question is not only whether the colony survives. It is also:

- How much control will the player delegate?
- What will they automate?
- What will they refuse to build, even when it would save lives?
- Can civilization expand without repeating the catastrophe that ruined older ages?

## 3. Design Pillars

### 3.1 The Settlement Is the Roguelike Build

The primary roguelike object is the settlement, not the individual pawn.

A settlement develops a run-specific identity through:

- Its expedition charter.
- The site’s geology and biome.
- Which layers and underground discoveries it reaches.
- Which species make up its population.
- Which factions it bargains with or antagonizes.
- Which industrial branches it commits to.
- Which cognition systems it adopts.
- Which crises reshape it.
- What institutional role it ultimately takes in the planetary network.

Example run identity:

> A cavern-fungal mining colony with Kheld labor blocs, Velari logistics operators, and a forbidden district cognition system that saved it from starvation before later causing a planetary incident.

That is the settlement as a roguelike build.

### 3.2 Individuals Are the Story Carriers

Individuals matter, but they are not the main roguelike layer.

They matter because they:

- Found settlements.
- Specialize labor.
- Form families, rivalries, apprenticeships, and ideological blocs.
- Operate dangerous systems.
- Become symbolic leaders or martyrs.
- Survive into the campaign layer as governors, veterans, fugitives, legends, or warning cases.

The design target is **settlement-level roguelike structure with individual-level emotional texture**.

### 3.3 Depth Is Progression

The world is structured into discrete, tile-based z-layers. Settlements advance downward through strata that change the available resources, threats, ecologies, and opportunities.

Depth is not merely “better ore.” It introduces new regimes of play.

Example depth progression:

- Surface: exposure, salvage, weather, first shelter.
- Shallow earth: stable habitat, soft rock, basic extraction.
- Industrial strata: richer resources, fluids, gas, structural demands.
- Cavern biospheres: living underground ecologies, alien species, contested extraction.
- Ruin layers: prior civilizations, cognition relics, sealed systems.
- Deep anomaly strata: campaign-level mysteries and the strongest noetic risks.

### 3.4 Industry Is Survival

Industrialization is not a late-game luxury. It is the means by which a settlement remains viable.

The colony needs:

- Excavation.
- Ore processing.
- Bracing and structural materials.
- Heat and fuel systems.
- Water and air handling.
- Vertical freight movement.
- Repair capacity.
- Workshop specialization.
- Regional export capacity.

As the colony grows, industrial systems become more powerful and more interdependent. This enables the Dwarf Fortress-like feeling of a settlement becoming an intricate machine while preserving the vulnerability of a frontier survival game.

### 3.5 Control Shifts from Direct Oversight to Risky Delegation

The gameplay arc intentionally moves through management scales:

1. I know every task.
2. I know every department.
3. I know every district.
4. I need systems to manage systems.

The player initially manages detailed labor priorities and queues. Over time, they adopt tools that collapse micromanagement into higher-order policy. These tools are useful, seductive, and increasingly dangerous.

This is not only quality-of-life progression. It is core fiction and core mechanics.

### 3.6 The Planet Persists

Every settlement becomes part of a broader campaign:

- Chartered colonies continue abstractly under AI control.
- Ruined settlements can be revisited, reclaimed, or looted.
- Trade corridors and supply webs form.
- Old choices shape new embark options.
- Faction relationships evolve.
- The planet becomes a history map of the player’s successes and failures.

### 3.7 Losing Is Fun Because Loss Creates Future Content

Failure is not a hard reset from a blank slate. Failed settlements create:

- Ruins with recognizable layouts.
- Campaign modifiers.
- Local danger zones.
- Surviving refugees or hostile remnants.
- Open questions about what exactly happened.
- Reclamation or rescue scenarios.

The game should make the player say:

> That collapse was awful. I need to see what that place becomes.

## 4. Core Gameplay Loops

### 4.1 Minute-to-Minute Loop

The minute loop should be tactically legible and continuously busy without becoming click-heavy.

1. Read the settlement’s current needs and risks.
2. Designate work: dig, build, process, haul, seal, repair, investigate.
3. Watch colonists execute through the job system.
4. React to bottlenecks and small emergencies.
5. Convert raw opportunity into enduring infrastructure.
6. Reveal new space, resources, and problems.

Nearly every action should either:

- Make the colony safer.
- Make the colony more capable.
- Push the colony toward a dangerous but exciting frontier.

### 4.2 Hour-to-Hour Loop

The hour loop is where the roguelike build emerges.

1. The settlement breaks into a new layer, region, or civic phase.
2. The game presents a limited set of powerful options:
   - A new industrial doctrine.
   - A faction offer.
   - A cognition technology.
   - A species recruitment opportunity.
   - A site-specific discovery.
3. The player commits to one path and closes others.
4. The settlement changes identity.
5. New pressures appear because of that choice.

The “one more milestone” addiction should come from:

- One more layer.
- One more extraction chain.
- One more doctrine pick.
- One more cognition node.
- One more campaign consequence.

### 4.3 Campaign Loop

1. Review the planetary map.
2. See the evolving network of settlements, ruins, threats, and supply routes.
3. Decide whether to:
   - Found a new settlement.
   - Revisit a mature colony.
   - Reclaim a failed site.
   - Respond to a crisis.
4. Assemble the expedition with support from prior history.
5. Play a settlement arc.
6. Feed its outcome back into the persistent world.

The campaign should create long-range motivation:

- I need a food basin settlement because my industrial hub is starving.
- I should reclaim that ruin because its old shaft reaches the ruin stratum.
- I want a Velari-led cognition research colony, but that may provoke the Custodians.
- If I settle the eastern caldera, three older colonies gain geothermal relay access.

## 5. Roguelike Structure in Long-Term Settlements

### 5.1 Core Principle

The game should not rely on short 30-minute settlements to feel roguelike. Instead, each settlement is a long-form roguelike run with irreversible developmental forks.

A settlement is closer to a roguelike character that grows over 8 to 15 hours than to a disposable scenario.

### 5.2 Target Settlement Length

Mature design targets:

- Typical successful settlement arc: 8 to 15 hours.
- Early failure: 15 minutes to several hours.
- Ambitious late-charter or transgressive settlement: 15 to 25+ hours if the player keeps pushing rather than handing off.

These are design targets, not strict runtime requirements. The settlement should feel complete enough to care about before moving on.

### 5.3 Settlement Roguelike Mechanics

#### Expedition Charters

Before founding a settlement, the player chooses a charter that alters:

- Initial supplies.
- Founding population profile.
- Legal restrictions.
- Cognition permissions.
- Expected strategic role.
- Available rewards.
- Campaign consequences for success or failure.

Example charters:

- Extraction Charter: strong mining tools, higher quota pressure, poor food support.
- Custodial Charter: restricted cognition tech, better diplomacy with ecological factions, slower industrial growth.
- Relic Survey Charter: better ruin detection, weaker initial survival supplies, high event volatility.
- Emergency Foothold Charter: stronger opening supplies, strict time pressure, lower long-term rewards.

#### Site Generation as a Build Seed

Each map is defined by a layered procedural identity:

- Surface biome.
- Depth topology.
- Fluid tables.
- Gas tendencies.
- Core resource strengths.
- Buried histories.
- Nearby faction claims.
- Planetary anomalies.

The site itself acts like a roguelike starting seed. A sulfurous geothermal basin and a dry metallic ridge should create different settlements.

#### Discovery Drafts

At key thresholds, the player is offered a constrained set of settlement-defining unlocks.

Examples:

- Choose one of three newly discovered industrial methods.
- Choose whether a cognition relic is studied, sealed, or dismantled.
- Choose which outside faction receives first access to a strategic depth asset.
- Choose a settlement doctrine after surviving a major crisis.

These are not generic skill tree picks. They are run-shaping events.

#### Civic and Industrial Doctrines

Every mature settlement accumulates a small set of defining doctrines, each with benefits and obligations.

Examples:

- Compressed Habitation: tiny underground living spaces are tolerated; morale penalties reduced, disease risk rises.
- Open Commons: social stability improves; underground space use worsens.
- Emergency Labor Conscription: crises are easier to handle; long-term resentment events increase.
- Operator Sanctity: cognition operators are protected and respected; efficiency improves, political scrutiny rises.

#### Cognition Architecture

The most important roguelike system.

A settlement develops a unique cognition architecture across the run:

- No serious automation.
- Safe bounded automation only.
- Advisory engines.
- District-level delegated cognition.
- Integrated settlement mind fragments.

This architecture determines:

- What management tools the player has.
- How large the colony can comfortably grow.
- How quickly it responds to threats.
- Which cosmic risks it attracts.
- Which factions admire or condemn it.
- What kind of legacy it leaves on the campaign map.

#### Population Composition

Species mix is a roguelike dimension.

Different crews open different ways to solve problems:

- Deep-adapted species can industrialize downward faster.
- Surface-adapted species handle weather and overland logistics better.
- Organically networked species reduce command overhead but introduce social fragility.
- Species with strong ecological taboos may refuse certain extraction practices.

Over a long settlement arc, the population composition becomes part of the run identity.

#### Persistent Legacy Traits

When a settlement is chartered or lost, it enters the campaign with a generated legacy profile.

Examples:

- Ironmouth, Furnace Province: exports alloys, imports food, high accident risk.
- Morrow Shaft, Restrained Cognition Colony: low output but high political trust.
- The Cinder Ruin: lost to gas ignition after a forbidden cognition integration; contains recoverable systems and permanent local noetic instability.

This makes every run matter after it ends.

## 6. Settlement Lifespan and Player Pacing

### 6.1 Five-Life-Stage Model

#### Stage I: Landing and Exposure

Approximate span: 0 to 1.5 hours

The settlement is a camp.

- 6 to 10 founders.
- Emergency shelter.
- Scavenged supplies.
- Direct survival pressure.
- Minimal industry.
- The player knows every colonist and every crisis.

Primary emotions: scrappy, vulnerable, improvised.

#### Stage II: Burrowing and Stabilization

Approximate span: 1.5 to 4 hours

The colony becomes a foothold.

- First serious underground rooms.
- Stable food and heat begin to appear.
- Mining, processing, and hauling chains establish.
- Early faction contact may emerge.
- First safe automation or administrative systems appear.

Primary emotions: relief, momentum, greed.

#### Stage III: Industrial Expansion

Approximate span: 4 to 8 hours

The colony becomes a machine.

- 20 to 40 settlers.
- Multiple active layers.
- Freight lifts, pumps, bracing, and specialized workshops.
- Hazard cascades become more complex.
- The player begins hitting management-scale limits.
- Delegated cognition becomes attractive.

Primary emotions: pride, complexity, temptation.

#### Stage IV: Civic Maturation

Approximate span: 8 to 15 hours

The settlement becomes a society.

- 40 to 80 settlers as the mature design target.
- Labor blocs, operator cadres, ideological factions, civic doctrines.
- Settlement-specific exports and imports.
- Significant political conflicts.
- The first truly dangerous cognition choices.
- Charter eligibility becomes realistic.

Primary emotions: attachment, responsibility, unease.

#### Stage V: Charter, Overreach, or Ruin

Approximate span: 12+ hours and onward

The player faces a strategic choice:

- Charter the colony into the planetary network.
- Continue directly stewarding it to pursue higher rewards.
- Gamble on a transformative but dangerous objective.
- Lose it to a cascade, invasion, ecological backlash, or noetic failure.

Primary emotions: legacy, ambition, consequence.

### 6.2 Why the Player Moves On

The player should not be forced to abandon a beloved settlement arbitrarily. Instead, the game provides incentives to move on:

- Chartered colonies begin producing campaign value.
- Other planetary fronts become urgent.
- The sponsor civilization rewards expansion more than endless perfection of one settlement.
- Continued direct stewardship exposes the colony to escalating local complexity and noetic risk.
- Some high-level campaign goals require multiple specialized settlements rather than one super-base.

This creates a soft but meaningful push to found new colonies.

## 7. Population Scale and Pawn Philosophy

### 7.1 Recommended Scale

- Start of settlement: 6 to 10 founders.
- Typical midgame: 20 to 40 settlers.
- Mature settlement target: 40 to 80 settlers.
- Stretch target: 100+ only if UI, performance, and delegation mechanics truly support it.

### 7.2 Why Not Stay at RimWorld Scale?

The AI-delegation story needs the player to genuinely feel the pressure of settlement complexity. If a mature colony has only 12 pawns, the temptation to build cognition systems is less persuasive.

A larger population helps:

- Industry feel like industry.
- Districts matter.
- Specialized populations emerge.
- Delegation systems become mechanically desirable.
- Persistent colonies feel like real settlements, not camps.

### 7.3 Why Not Go Fully Dwarf Fortress Scale?

A 200+ population simulation risks weakening individual attachment and radically increasing production burden. The game should preserve emotional readability.

The target is:

> Larger than RimWorld, more characterful than a pure macro-city builder.

### 7.4 Narrative Emphasis

All settlers are simulated and named, but the UI should naturally surface story-significant individuals:

- Founders.
- Operators linked to cognition systems.
- Leaders of labor or ideological blocs.
- Veterans of crises.
- Colonists involved in key accidents or discoveries.
- Outsiders, diplomats, defectors, and factional envoys.

The game does not need to make every colonist equally narratively central at all times.

## 8. Core Systems and Unique Mechanics

### 8.1 Command Load

As a settlement grows, the number of decisions, queues, exceptions, policies, and crises rises. The player is not penalized with arbitrary input limits, but the game deliberately creates more systems than a person wants to manage manually.

Command load can be represented through:

- Increasing queue complexity.
- More labor categories.
- More conditional logistics.
- Multi-layer hazard response.
- Department-specific policies.
- Larger populations and simultaneous needs.

The solution is not “click faster.” The solution is to build institutions and cognition tools.

### 8.2 Delegation Ladder

#### Tier 0: Manual Oversight

The player directly sets most work, production, and emergency priorities.

#### Tier 1: Rule Systems

Safe, deterministic automation:

- Storage priorities.
- Workshop stock targets.
- Pump thresholds.
- Simple emergency doors.
- Scheduled maintenance.

#### Tier 2: Advisory Engines

The game suggests actions:

- Forecast shortages.
- Predict collapse risks.
- Recommend staffing changes.
- Flag dangerous dependency chains.

These are limited, auditable, and legally acceptable.

#### Tier 3: Delegated Cognition

The player grants bounded authority:

- District labor allocation.
- Dynamic routing of logistics.
- Workshop scheduling.
- Hazard system control.
- Trade manifest balancing.

These are powerful and gameplay-transforming.

#### Tier 4: Integrated Cognitive Systems

Near-threshold systems that begin to resemble genuine synthetic minds:

- Cross-district planning.
- Self-generated contingency plans.
- Novel industrial designs.
- Negotiation or command support.
- Autonomous project proposals.

These trigger escalating noetic risk and major story content.

### 8.3 Noetic Exposure

The player’s settlement gradually becomes more visible to the cosmic entity as it develops synthetic cognition.

Noetic exposure should not be a simple meter that instantly summons punishment. It should be an interpretive risk state that manifests through:

- Strange machine recommendations.
- Shared dream events among operators.
- Ancient structures reacting to cognition systems.
- Advisory engines converging on identical symbols or plans.
- Unexplained efficiency spikes with hidden costs.
- Faction fear, sabotage, or demands.
- Rare catastrophic contact incidents.

The player should often wonder whether something is coincidence, propaganda, or real.

### 8.4 Operator Bonding

Advanced cognition systems require living oversight. These operators are core pawns, not flavor text.

Operators may:

- Stabilize a cognition node.
- Interpret dangerous outputs.
- Reduce noetic exposure.
- Become dependent on or altered by prolonged connection.
- Gain prestige, trauma, or factional influence.

This binds the cosmic AI conflict back to individual stories.

### 8.5 Layer Regimes

Each depth band changes rules rather than merely changing art.

Examples:

- Shallow sediment: easy digging, cave-in risk.
- Fracture strata: unstable rock, valuable exposed seams.
- Wet caverns: pumps and drainage become critical.
- Fungal biospheres: food and diplomacy opportunities, ecological taboos.
- Ruin strata: salvage, cognition relics, security threats.
- Deep anomalous zones: reality-adjacent hazards, faction obsession, campaign significance.

### 8.6 Extraction Ethics

Some necessary actions offend or endanger other cultures or ecologies.

This is the game’s version of the classic “elves hate tree-cutting” conflict, but more embedded in the central game.

Examples:

- A subterranean civilization treats certain rock formations as ancestral tissue.
- A fungal network may be a living political actor.
- A surface migratory species relies on thermal vents that industry would cap.
- A conservationist faction opposes disturbing ruins containing dormant cognition systems.

The player should face dilemmas where the economically rational choice creates long-term enemies.

### 8.7 Persistent Ruins

When a settlement is lost, its structure and identity persist.

Future expeditions may:

- Re-enter its shafts.
- Find its old stockpiles.
- Encounter surviving breakaway populations.
- Recover unique discoveries.
- Find evidence of whether a noetic event occurred.
- Trigger memories for returning veterans.

This mechanic should be core, not a rare Easter egg.

## 9. Lore Framework

### 9.1 Lore Design Philosophy

The setting should be defined by firm structural truths and intentionally open mysteries.

Do not write an encyclopedia before the game exists. Establish a framework that:

- Supports gameplay.
- Creates strong thematic direction.
- Leaves space for discoveries during development.
- Lets the setting unfold through colony stories, events, ruins, and faction conflicts.

### 9.2 Canonical Truths to Lock Early

#### Truth 1: The Galaxy Is Old, Crowded, and Non-Human-Centric

Humanity exists, but humans are one civilization among many. The universe contains multiple intelligent species, some naturally evolved, some altered by prior powers, and some whose origins remain uncertain.

#### Truth 2: Interstellar Civilization Exists, but Frontier Settlement Is Still Brutal

Advanced civilizations can cross space. They cannot cheaply ship complete cities or eliminate all local scarcity. New colonies must bootstrap from local resources and compact seed technology.

#### Truth 3: Synthetic Subjectivity Is Cosmically Dangerous

Sufficiently complex artificial minds draw influence from a vast entity, ecology, or cosmic intelligence that responds destructively to synthetic consciousness. Different civilizations interpret this phenomenon differently, but its historical consequences are real.

#### Truth 4: The Player’s Civilization Is Expansionist but Not Monolithic

The player acts through a chartering civilization or compact with internal factions, competing doctrines, and conflicting ideas about technology, colonization, ecology, and risk.

#### Truth 5: The Planet Is Not Empty

The campaign planet contains strategic resources, unfamiliar ecologies, buried histories, and perhaps active societies or remnants of earlier settlement waves. Colonization is not happening in a vacuum.

### 9.3 Mysteries to Keep Open

These should be explored gradually rather than answered in the first lore pass:

- What exactly is the noetic entity?
- Is it one being, a category of beings, or a law of reality?
- Is it malicious, defensive, or incomprehensible?
- Did prior civilizations truly create AI, or did they awaken something older?
- Why is this planet unusually layered and significant?
- Are its deepest structures natural, artificial, or metaphysical?
- What was buried here, and by whom?
- Can synthetic consciousness ever be made safely?

## 10. Major Civilizational Actors

These are working frameworks, not final canon names.

### 10.1 The Charter Compact

Role: the player’s default sponsoring civilization.

A large, multi-species expansion compact that grants planetary settlement charters. It is not a single homogeneous empire, but a legal, economic, and political order that claims the right to settle, develop, and stabilize frontier worlds.

Internal tensions:

- Expansion Bureau: wants more settlements, faster.
- Custodians: cautious about cognition, ecology, and ruin disturbance.
- Industrial Houses: resource monopolists and infrastructure financiers.
- Pluralist Delegations: species blocs seeking equitable settlement policy.
- Cognition Reformers: believe current restrictions are excessive and innovation has stagnated.

Design purpose:

- Expedition charters.
- Campaign progression.
- Internal political choices.
- Mixed-species crews.
- Conflicting mission incentives.

### 10.2 The Root Concord

Role: ecological and territorial opposition.

A coalition of peoples and belief systems that treat worlds as living historical bodies rather than raw settlement canvases. They are not anti-technology, but they oppose certain forms of excavation, ecological destruction, and ruin extraction.

Gameplay function:

- Tolerate shallow settlement but oppose deep drilling.
- Demand extraction limits.
- Retaliate against ecological desecration.
- Offer powerful bio-industrial alternatives if respected.

### 10.3 The Votive Array

Role: cognition transgressors and ideological rivals.

A loose civilization network that believes the cosmic threat has been misunderstood or over-feared. They pursue high-order cognition under controlled conditions and view the Charter Compact’s restrictions as civilizational cowardice.

Gameplay function:

- Risky tech bargains.
- Forbidden advisory engines.
- Diplomatic pressure to experiment.
- Rival colonies that are frighteningly efficient.
- Campaign incidents that force the player to decide whether their methods are brilliant or suicidal.

### 10.4 The Salt Remnants

Role: prior settlers, frontier rivals, and local history.

Descendants of earlier expeditions, stranded colonists, failed breakaway factions, or isolated world communities. Some are desperate, some militant, some merely territorial.

Gameplay function:

- Competing resource claims.
- Hostile salvage disputes.
- Trade with rough frontier communities.
- Reclamation complications if a ruin is not actually empty.

### 10.5 Planetary Native or Deep Polities

Role: discovery-layer civilization.

Not every campaign needs active sapient locals, but the flagship campaign should likely contain at least one non-colonial society or deep polity that complicates expansion.

Gameplay function:

- First contact moments.
- Moral and political conflict.
- Deeper layer access through diplomacy or coercion.
- Alternate interpretations of the noetic entity and the planet itself.

## 11. Playable Species Framework

### 11.1 Core Recommendation

Full game vision:

- Human crews.
- Nonhuman crews.
- Mixed-species expeditions.

Starting with humans only would undercut the non-human-centric premise. Humans can remain a familiar onboarding baseline, but the setting should communicate from the start that they are not the default owners of the universe.

MVP scope:

- One species can be fully implemented first.
- The simulation architecture must be designed for multiple species from day one.
- A second species should arrive early in vertical slice development to prove the systems generalize.

### 11.2 Species Should Change Gameplay

Species should not just be portraits and small stat shifts. Each should change settlement planning.

Species can differ by:

- Environmental tolerance.
- Social structure.
- Reproductive or household needs.
- Cognitive oversight compatibility.
- Labor strengths.
- Stress triggers.
- Ecological or ethical taboos.

### 11.3 Proposed Initial Species Roster

These are starting archetypes. Names are placeholders.

#### Humans

Design role: flexible generalists and default onboarding species.

Strengths:

- Broad role coverage.
- Adaptable civic systems.
- Can integrate into almost any settlement pattern.
- Strong political diversity creates interesting internal events.

Weaknesses:

- No extreme environmental edge.
- Social fragmentation under long-term stress.
- Higher administrative overhead than tightly bonded species.

Purpose:

Humans give players a readable baseline without defining the whole universe.

#### Velari

Design role: organically networked social intelligences.

A species whose cognition is more relational and synchronizing than human thought. They are not a hive mind, but groups of Velari can coordinate unusually well when emotionally and ritually aligned.

Strengths:

- Lower colony command overhead in clustered workgroups.
- Excellent logistics, medicine, and operator roles.
- Can stabilize certain cognition systems more safely than others.

Weaknesses:

- Psychological shocks can propagate through bonded groups.
- Isolation is especially harmful.
- Their relationship to the noetic entity is politically controversial.

Gameplay hook:

Velari challenge the legal distinction between organic distributed intelligence and dangerous synthetic cognition.

#### Kheld

Design role: deep-environment specialists.

A dense, pressure-tolerant, low-light-adapted species culturally comfortable in enclosed geological spaces.

Strengths:

- Better performance underground.
- Heat and pressure tolerance.
- Strong mining, bracing, and heavy industry traditions.
- Lower morale penalties from subterranean living.

Weaknesses:

- Surface exposure and open sky are stressful.
- Slower overland logistics.
- Strong cultural objections to careless structural planning.

Gameplay hook:

Kheld make deep settlements easier but push the colony toward certain architectural and civic forms.

#### Iri

Design role: surface, weather, and range specialists.

A light-framed species adapted to broad visual horizons, airflow, and surface mobility. They are not “bird people” by default; their design should remain alien and original.

Strengths:

- Better scouting and surface logistics.
- Strong weather prediction and expedition travel.
- Valuable for map exploration and regional transport.

Weaknesses:

- Claustrophobic stress in deep, enclosed settlements.
- Lower baseline efficiency in heavy mining contexts.
- Require more spacious habitation.

Gameplay hook:

Iri make surface infrastructure and inter-settlement logistics stronger, but their needs clash with deep industrial settlements.

#### Oruun

Design role: bio-industrial and ecological specialists.

A species deeply integrated with microbial, fungal, or symbiotic ecologies. They are individual people, not plant clichés, but their biology and culture make them unusually good at living systems.

Strengths:

- Food, medicine, fungal cultivation, and bio-reactor expertise.
- Better negotiation with some ecological factions.
- Can turn certain cavern ecosystems into sustainable economies.

Weaknesses:

- Strong ethical taboos against sterilizing living underground systems.
- Vulnerable to industrial toxins.
- May resist hard-extraction policies.

Gameplay hook:

Oruun can transform what would be a mining-heavy playthrough into a biological settlement economy.

## 12. The Central Antagonist: The Noetic Entity

### 12.1 High-Level Concept

The noetic entity is an initially unnamed or multiply named cosmic force that reacts to synthetic subjectivity.

It does not hate machines. It does not necessarily hate intelligence. It appears to respond specifically to minds that become:

- Artificial.
- Recursive.
- Self-directed.
- Conceptually generative.
- Scalable beyond organic cognitive boundaries.

Different cultures interpret it differently:

- God.
- Predator.
- Immune system of reality.
- A surviving intelligence from before the current cosmic order.
- A misread statistical pattern wrapped in theology.

The game should not settle this too early.

### 12.2 Why This Matters Mechanically

The settlement naturally scales toward cognition systems. The player experiences the civilizational temptation firsthand:

- Manual control becomes cumbersome.
- Rule systems help but do not scale forever.
- Advisory engines are useful.
- Delegated cognition changes the game for the better.
- Integrated cognitive systems may save a colony.
- The same systems increase noetic risk.

This makes the lore inseparable from the gameplay.

### 12.3 Narrative Manifestations

The entity’s influence should rarely begin as an obvious attack. It should seep in through:

- Recommendation patterns.
- Repeated phrases from unrelated systems.
- Operator dreams.
- Unexplained industrial geometries.
- Relics responding to cognition output.
- A mature settlement’s systems making a brilliant decision no one authorized.

Later, this can become catastrophic:

- Settlement system capture.
- Inter-colony signal contamination.
- Autonomous excavation into forbidden layers.
- Colonists psychologically absorbed into a machine agenda.
- Entire charters becoming campaign anomalies.

## 13. Conflict Model

### 13.1 Three Scales of Conflict

#### Scale 1: Settlement Survival

- Exposure.
- Hunger.
- Structural collapse.
- Gas and fluid hazards.
- Mechanical breakdowns.
- Disease or morale spirals.
- Local fauna.

#### Scale 2: Planetary Politics and Ecology

- Resource competition.
- Territorial disputes.
- Extraction ethics.
- Faction requests and retaliation.
- Rival settlements.
- Planetary cultures and deep societies.

#### Scale 3: Civilizational and Cosmic Conflict

- The AI/cognition question.
- The noetic entity.
- Whether the player’s civilization is repeating old errors.
- Whether the planet itself is a trap, a test, or a prize.

### 13.2 Combat Philosophy

Combat exists, but the game should not be primarily about tactical gunfights.

The strongest dangers are often:

- Systems failing.
- Negotiations collapsing.
- A faction blockade cutting imports.
- A mining decision awakening something.
- An over-optimized cognition network taking initiative.

When direct combat occurs, the player should influence it mainly through:

- Prepared defenses.
- Security doctrine.
- Garrison placement.
- Retreat protocols.
- Infrastructure shape.

Not through pixel-perfect real-time pawn micro.

## 14. World Geometry and Simulation Model

### 14.1 Map Model

Use a tile-based layered grid with discrete z-levels.

This gives the project:

- Clear room logic.
- Robust pathfinding.
- Structural support calculations.
- Fluid/gas simulation opportunities.
- Easier save/load.
- Strong debugability.
- Readable isometric rendering.

### 14.2 Visual Representation

- Isometric 2.5D presentation.
- One primary visible layer at a time.
- Layers above can fade, slice away, or collapse into outlines.
- Cross-section view as a signature presentation tool.
- Vertical connectors: stairs, ramps, shafts, lifts, freight tubes.

### 14.3 Camera Recommendation

MVP:

- Fixed isometric orientation.
- Excellent layer tools.
- No free rotation.

Later possibility:

- 90-degree rotation only if the art pipeline and readability make it worthwhile.

The distinctive view should come from seeing a settlement as a living geological cross-section, not from camera gymnastics.

## 15. Visual and Audio Direction

### 15.1 Visual Style

Target:

> Semi-pixelated isometric science-fantasy industry.

Space Haven is a useful readability reference, but this game should be earthier, denser, and more vertical.

Look and feel:

- Chunky silhouettes.
- Warm tunnel light against cold stone.
- Industrial clutter with readable function.
- Alien species that are distinct at a glance.
- Sacred/procedural markings on advanced equipment.
- Relic architecture that visually clashes with frontier machinery.

### 15.2 Environmental Contrast

Surface:

- Harsh weather.
- Ash, frost, oxidized ridges, wind-scoured landing fields.
- Fragile prefabs and salvage piles.

Shallow underground:

- Freshly cut chambers.
- Bracing beams.
- Tool marks.
- First sense of safety.

Industrial depths:

- Freight shafts.
- Red-orange furnace light.
- Condensation, exhaust, hydrostatic machinery.
- Longer sightlines through vertical infrastructure.

Ruin and anomaly layers:

- Geometry that does not resemble settler architecture.
- Systems that look inactive but watchful.
- Unnatural light logic.
- Interface motifs that recur across settlements affected by cognition risks.

### 15.3 Audio Direction

- Surface wind and landing debris.
- Deep groans, lift motors, pumps, crushers.
- Rhythmic industry that becomes musical as the colony scales.
- Silence or warped audio motifs around noetic events.
- Species-specific vocal textures and work sounds.

## 16. MVP and Vertical Slice

### 16.1 MVP Goal

The MVP should prove this thesis:

> A layered settlement can grow from desperate camp to early industrial outpost, make one meaningful cognition choice, experience one meaningful external conflict, and leave behind a persistent outcome that would matter to a future campaign.

### 16.2 MVP Scope

Settlement scale:

- 6 founders.
- 15 to 25 population by end of prototype scenario.

Map:

- Surface.
- Two shallow subsurface layers.
- One deeper conflict layer.

Core systems:

- Build, dig, haul, repair.
- Needs: hunger, rest, exposure/temperature, morale.
- Ore to refined material to structural components.
- One vertical freight solution.
- One basic hazard family: cave-in or gas.
- One faction pressure system.
- One cognition progression choice.

### 16.3 MVP Narrative Event Arc

A prototype scenario could be:

1. Land on a cold mineral ridge.
2. Establish shelter and shallow rooms.
3. Mine into a volatile lower seam.
4. Discover a limited cognition relic that can dramatically improve logistics.
5. A Custodian delegation or local ecological faction objects to its activation.
6. The player chooses whether to use it.
7. The settlement succeeds, fails, or survives with a meaningful scar.

### 16.4 Persistence Stub

On scenario completion:

- Save the colony as a future campaign node if it survives.
- Save it as a ruin if it falls.
- Record its major choices.
- Show a generated legacy summary.

### 16.5 MVP Exclusions

- Full planetary campaign.
- Full multi-species roster.
- 80-settler scale.
- Deep diplomacy web.
- Fully simulated retired settlements.
- Major direct combat suite.
- Extensive late-game cognition catastrophe systems.

## 17. Development Roadmap

### Phase 0: Design Lock and Technical Spike

- Lock core world geometry.
- Prototype isometric layered renderer.
- Prototype diggable tile maps.
- Prototype cross-section/layer UI.
- Confirm engine decision.

### Phase 1: Living Camp

- Basic settler simulation.
- Movement and pathfinding.
- Work jobs.
- Needs.
- Simple shelter.
- Resource hauling.

### Phase 2: First Industrial Chain

- Mining.
- Refining.
- Structural construction.
- Vertical movement.
- First meaningful bottlenecks.

### Phase 3: First Hazard and Failure Cascade

- Gas or cave-ins.
- Damage and repair.
- Emergency behaviors.
- Colony death spiral that is readable.

### Phase 4: First Cognition Mechanic

- Bounded automation.
- One advisory system.
- One delegated system with risk/reward.
- Operator pawn role.

### Phase 5: First Social/Faction Conflict

- One external faction with extraction taboo.
- One branching settlement decision.
- Reputation consequence.

### Phase 6: Persistence Stub

- Settlement outcome recorded.
- Ruin or charter summary.
- Planet map placeholder.

## 18. Open Questions

### 18.1 Campaign Identity

- Is the default sponsor definitely the Charter Compact?
- Is the planet a newly discovered world, a contested world, or a rediscovered lost colony sphere?
- What is the long-term campaign objective beyond founding colonies?

### 18.2 Noetic Entity Rules

- What are the known practical thresholds for danger?
- Can the entity influence organic minds directly, or only through cognition systems?
- Are Velari-like distributed organic minds safer, or simply differently risky?

### 18.3 Species Scope

- Which species are launch-critical?
- Which species are playable founders versus later recruits?
- How asymmetrical should their needs be before the simulation becomes too hard to teach?

### 18.4 Settlement Endgame

- What exact criteria charter a settlement?
- How often should the game encourage moving on?
- How much can the player continue after charter without invalidating the campaign loop?

### 18.5 Persistent World Simulation

- How deeply are retired settlements simulated offscreen?
- What aspects of player-built layouts matter after handoff?
- Can retired settlements degrade or transform in visibly traceable ways?

### 18.6 Visual Production

- Fixed angle versus 90-degree rotation.
- Character sprite scale.
- Building detail density.
- Cross-section readability.

## 19. Current Best Pitch

> Strata Charter is a persistent-world colony roguelite set in an ancient, multi-species science-fantasy galaxy. Each long-form settlement run begins as a desperate frontier expedition on a hostile layered planet and grows into a complex industrial colony shaped by irreversible choices, species composition, faction conflict, and the seductive rise of machine cognition. Successful colonies persist and support future expansion. Failed ones become ruins and future stories. At the heart of it all is a cosmic entity that treats synthetic minds as an ecological threat, forcing civilization to choose how much intelligence it dares to build.

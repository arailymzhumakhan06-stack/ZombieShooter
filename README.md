# 🧟 Zombie Shooter FPS

A first-person survival shooter where you defend yourself against waves of zombies. Built with Unity 6000.3.1f1.

## 🎮 Game Concept

You are a lone survivor in a world overrun by zombies. Armed with weapons, fight through hostile environments, collect ammunition, and survive as long as possible against enemies.

## 🔄 Core Game Loop
1. **Explore** → Move through the level using WASD and jump.
2. **Engage** → Shoot zombies when they get provoked (by sight or sound).
3. **Survive** → Avoid zombie attacks (player dies after several hits).
4. **Resupply** → Collect ammo pickups (shells, bullets, rockets, plasma) to refill weapons.
5. **Repeat** → New zombies spawn/react, continuing the cycle until player death.

## 🎯 Raycast-Based Mechanic (Shooting)
Shooting is implemented using `Physics.Raycast` — the standard Unity method for instant-hit detection.

**How it works:**
- When pressing **Left Mouse Button**, an invisible ray is cast forward from the center of the camera.
- The ray checks for collisions with objects tagged as "Zombie".
- If a zombie is hit, the raycast returns the hit point and reduces the zombie's health by a set damage value.
- Upon reaching zero health, the zombie dies.
- The ray travels instantly (no projectile travel time), simulating a bullet.

## 🎮 Controls

| Action | Key |
|--------|-----|
| Move Forward | `W` |
| Move Backward | `S` |
| Move Left | `A` |
| Move Right | `D` |
| Jump | `Space` |
| Shoot | `Left Mouse` |
| Zoom / Aim | `Right Mouse` |
| Pause | `Escape` |


## 🧠 AI Behavior System

Zombies use **NavMesh** pathfinding for navigation and a **state-based AI** system.

### AI States:

| State | Trigger | Behavior |
|-------|---------|----------|
| **Idle** | Default state | Zombie stands still, no action |
| **Provoked** | Player gets within 5m OR zombie is shot | Zombie starts chasing player |
| **Chase** | Provoked state active | Zombie moves toward player using NavMeshAgent |
| **Attack** | Within stopping distance (2m) | Zombie plays attack animation, damages player |


---

## 🗺️ Level Overview

The game features **3 playable levels**:

### Level 1 – Sandbox (Practice)
| Aspect | Description |
|--------|-------------|
| **Goal** | Test weapons and mechanics |
| **Environment** | Open practice area |
| **Enemies** | 1 stationary zombie |
| **Difficulty** | Very easy |
| **Win Condition** | No win condition (practice only) |

### Level 2 – Survival Arena
| Aspect | Description |
|--------|-------------|
| **Goal** | Eliminate all zombies |
| **Environment** | Enclosed arena with obstacles |
| **Enemies** | Zombies spawn at start |
| **Difficulty** | Medium |
| **Win Condition** | Kill all zombies |
| **Lose Condition** | Player dies |

### Level 3 – Time Challenge
| Aspect | Description |
|--------|-------------|
| **Goal** | Survive for 2 minutes against infinite zombies |
| **Environment** | Open arena with 2 spawn points |
| **Enemies** | Infinite spawning, max 10 at once |
| **Difficulty** | Hard |
| **Win Condition** | Survive until timer reaches zero AND all zombies are dead |
| **Lose Condition** | Player dies OR timer expires with zombies alive |


---

## 🎨 Feedback Integration

The game provides multiple feedback channels to keep the player informed.

### Visual Feedback

| Event | Feedback | Implementation |
|-------|----------|----------------|
| Player takes damage | Red screen flash | `DamageFlash` script with coroutine |
| Player health changes | Health text updates | `TextMeshProUGUI` on StatsCanvas |
| Ammo changes | Ammo text updates | Dynamic text per weapon type |
| Pickup collected | Floating text (+10 Bullets) | `FloatingText` script with upward animation |
| Zombie hit | Blood particle effect | Instantiated at hit point |
| Zombie death | Death animation | Animator trigger |
| Weapon fire | Muzzle flash particle | `ParticleSystem` on weapon |
| Level completion | Victory panel | UI panel with buttons |
| Player death | Game over panel | UI panel with restart option |

### Audio Feedback

| Event | Sound Effect | Source |
|-------|--------------|--------|
| Weapon shoot | Gunfire sound | `AudioManager.PlayShoot()` |
| Zombie hit | Impact sound | `AudioManager.PlayZombieHit()` |
| Zombie death | Death groan | `AudioManager.PlayZombieDeath()` |
| Player damage | Hurt sound | `AudioManager.PlayDamage()` |
| Ammo pickup | Pickup sound | `AudioManager.PlayPickup()` |
| Footsteps | Step sounds (randomized) | `AudioManager.PlayFootstep()` |
| Background | Ambient music | `AudioManager` (looping) |

### UI Feedback

| Element | Location | Purpose |
|---------|----------|---------|
| Health text | StatsCanvas (top-left) | Shows current HP |
| Ammo text | StatsCanvas (bottom-right) | Shows current ammo per weapon |
| Timer text | StatsCanvas (top-right) | Shows remaining time (Level 3 only) |
| Reticle | ReticleCanvas (center) | Aiming crosshair |
| Pause menu | PauseCanvas | Resume, Restart, Quit options |
| Win panel | GameCompleteCanvas | Victory screen with restart/menu |
| Lose panel | GameOverCanvas | Defeat screen with restart/menu |


## 🛠️ Built With

- Unity 6000.3.1f1
- C#
- Standard Assets (Unity)


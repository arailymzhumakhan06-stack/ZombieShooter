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


## 🛠️ Built With

- Unity 6000.3.1f1
- C#
- Standard Assets (Unity)


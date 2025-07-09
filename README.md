
````markdown
# 2D Crash Simulator

## Description
This project is a 2D interactive Unity simulation that models vehicle or object crashes using realistic physics. Users can adjust parameters such as mass, impact speed, elasticity, and impact offset through UI sliders and dropdowns to observe realistic collision physics, including forces, torques, kinetic energy, and angular velocity.

The simulation demonstrates core physics concepts applicable to real-world crash analysis. Optional stretch goals include exporting simulation data for offline hypothesis testing and analysis.

---

## Physics Concepts Covered

| Concept                  | Description                                        |
|--------------------------|--------------------------------------------------|
| Momentum & Kinetic Energy| How mass and speed determine impact forces       |
| Elastic Collisions       | Energy loss and rebound based on elasticity       |
| Torque & Angular Velocity| Off-center impacts causing rotation and spin      |
| Conservation of Energy & Momentum | Energy transfer during collisions          |

---

## Project Goals

- Implement physics simulation using Unity’s Rigidbody2D and Collider2D.
- Build UI controls for mass, speed, elasticity, and impact offset.
- Display real-time physics metrics such as angular velocity, kinetic energy loss, and rebound velocity.
- Include scenario presets and reset/replay functionality.
- (Stretch) Export simulation data (CSV) and run hypothesis tests offline.
- Prepare a report linking simulation results to physics concepts.
- Present a live demo highlighting interactivity and physics insights.

---

## Tech Stack

| Component       | Technology Used                 |
|-----------------|-------------------------------|
| Engine          | Unity (2D Physics Engine)       |
| Programming     | C# (Unity scripts)              |
| UI              | Unity UI (Sliders, Buttons)     |
| Data Analysis   | Python (pandas, scipy) or Excel (optional) |
| Version Control | Git + GitHub                    |

---

## Getting Started

### Prerequisites
- Unity 2023.x (or compatible version)
- Git
- Optional: Python 3.x with pandas & scipy (for data analysis)

### Installation
```bash
git clone https://github.com/yourusername/2d-crash-simulator.git
cd 2d-crash-simulator
# Open project in Unity Editor
````

### Usage

* Open the project in Unity.
* Use UI sliders to adjust crash parameters.
* Press Play to simulate crashes and observe results.

---

## Git Branching Instructions

### Creating and switching to a new branch

```bash
git checkout -b feature/your-feature-name
```

### Switching back to main branch

```bash
git checkout main
```

### Pushing a new branch to remote

```bash
git push -u origin feature/your-feature-name
```

---

## Checklist

* [ ] Initialize Unity project and Git repository
* [ ] Set up 2D scene with Rigidbody2D and Collider2D objects
* [ ] Implement UI sliders for mass, speed, elasticity, and impact offset
* [ ] Code physics logic to apply forces and torques on collision
* [ ] Display real-time physics metrics in the UI
* [ ] Add scenario presets and simulation control (reset/replay)
* [ ] (Optional) Export simulation data to CSV
* [ ] (Optional) Perform hypothesis testing and data analysis
* [ ] Test and debug the simulation thoroughly
* [ ] Prepare final report and presentation/demo

---

## Stretch Goals (Optional)

* Export simulation data for offline analysis.
* Conduct hypothesis tests on the effect of parameters like impact offset.
* Visualize trends in data and write a scientific summary.

---

## Visual & UX Suggestions

* Use simple geometric shapes and clean colors.
* Animate forces with arrows or particle effects.
* Keep UI intuitive and minimal.
* Show clear, real-time physics data during simulation.


```

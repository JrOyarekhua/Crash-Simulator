


# 🚗 2D Crash Simulator

A Unity-based physics simulation for analyzing vehicle collisions in 2D space.

## 📖 Description
This project is a 2D interactive Unity simulation that models vehicle or object crashes using realistic physics. Users can adjust parameters such as mass, impact speed, elasticity, and impact offset through UI sliders and dropdowns to observe realistic collision physics, including forces, torques, kinetic energy, and angular velocity.

The simulation demonstrates core physics concepts applicable to real-world crash analysis. Optional stretch goals include exporting simulation data for offline hypothesis testing and analysis.

---

## ⚛️ Physics Concepts Covered

| Concept                  | Description                                                                 |
|--------------------------|-----------------------------------------------------------------------------|
| **Momentum & Kinetic Energy** | How mass and speed determine impact forces                                |
| **Elastic Collisions**       | Energy loss and rebound based on elasticity                               |
| **Torque & Angular Velocity**| Off-center impacts causing rotation and spin                              |
| **Conservation Principles**  | Energy/momentum transfer during collisions                                |

---

## 🎯 Project Goals

### Core Implementation
✔ Implement physics using Unity's `Rigidbody2D` and `Collider2D`  
✔ Build interactive UI controls (sliders, dropdowns)  
✔ Display real-time physics metrics  
✔ Include scenario presets + reset functionality  

### Stretch Goals
🔲 Export simulation data (CSV)  
🔲 Hypothesis testing framework  
🔲 Scientific report linking results to physics  

---

## 🛠 Tech Stack

| Component       | Technology Used                          |
|-----------------|------------------------------------------|
| **Engine**      | Unity 2023.x (2D Physics)                |
| **Programming** | C# (Unity scripts)                       |
| **UI**          | Unity Canvas System                      |
| **Analysis**    | Python (pandas/scipy) or Excel (optional)|
| **VCS**         | Git + GitHub                             |

---

## 🚀 Getting Started

### Prerequisites
- Unity 2023.x+
- Git
- *(Optional)* Python 3.x with pandas/scipy

### Installation
```bash
git clone https://github.com/yourusername/2d-crash-simulator.git
cd 2d-crash-simulator
# Open in Unity Editor
```

### Usage
1. Launch project in Unity
2. Adjust parameters via UI controls
3. Click **Play** to simulate collisions
4. Observe real-time physics metrics

---

## 🌿 Git Workflow

### Branch Management
```bash
# Create and switch to new feature branch
git checkout -b feature/your-feature

# Return to main branch
git checkout main

# Push new branch to remote
git push -u origin feature/your-feature
```

---

## ✅ Development Checklist

- [x] Initialize Unity project + Git repo  
- [ ] Implement core physics (Rigidbody2D/Collider2D)  
- [ ] Design UI controls  
- [ ] Code collision response logic  
- [ ] Add metrics display  
- [ ] Create scenario presets  
- [ ] *(Optional)* Data export system  

---

## 🌟 Stretch Goals
- 📊 Advanced data visualization  
- 🔍 Hypothesis testing framework  
- 📝 Scientific write-up  

---

## 🎨 UX/UI Recommendations
- Use minimalist geometric shapes  
- Animate forces with vector arrows  
- Maintain clean, responsive interface  
- Highlight key metrics during simulation  


Key improvements:
1. Added emoji headers for visual scanning
2. Better table formatting with consistent alignment
3. Clearer checklist with completion indicators
4. More scannable section headers
5. Improved code block readability
6. Consistent bullet point styles
7. Added whitespace for better readability
8. Organized stretch goals separately
9. Streamlined tech stack presentation

# Introduction to Augmented Reality — Assignment 4

**Author:** Shengying Zhao (`szhao63`)  
**Course:** EN.601.454 / EN.601.654, Johns Hopkins University (Fall 2026)

## Contents

- **`Q1/Q1e.py`** — 1D Kalman filter for position/velocity estimation using noisy measurements.
- **`Q1/Q1f.py`** — Prediction-only version without measurement correction. Both scripts plot the simulated results.
- **`Q2/`** — Unity Roll-a-Ball-style game featuring a start button, keyboard movement and jumping, follow camera, collectibles, a speed/color power-up, a breakable wall, and a goal zone.

## How to Run

**Q1 — Python:** Install dependencies with `pip install numpy matplotlib`, then run `python Q1/Q1e.py` or `python Q1/Q1f.py` from the repository root to view the plots.

**Q2 — Unity:** Open the `Q2` folder as a project in Unity Hub (created with **Unity 6000.6.5f1**). Open `Assets/Scenes/SampleScene.unity` and press **Play**. Click **Start**, use **WASD / arrow keys** to move and **Space** to jump. Collect the cubes, pick up the power-up, break the special wall, and reach the goal.

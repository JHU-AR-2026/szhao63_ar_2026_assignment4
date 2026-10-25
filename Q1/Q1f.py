### JHU INTRODUCTION TO AUGMENTED REALITY (2026)
### Q1f. 1D Kalman Filter Prediction Without Measurement Correction
###
### This version uses the prediction step only.
### Measurements are generated and plotted for comparison,
### but they are not used to correct the state estimate.

import numpy as np
import matplotlib.pyplot as plt

# Simulation parameters
dt = 0.1        # time step
num_steps = 50

# True system model: constant velocity model in 1D
A = np.array([[1, dt],
              [0, 1]])  # state transition matrix

B = np.array([[0.5 * dt**2],
              [dt]])    # control matrix (for acceleration input)

H = np.array([[1, 0]])  # measurement matrix

# Process and measurement noise
sigma_process = 0.5
sigma_measure = 2.0

Q = sigma_process**2 * np.array([
    [dt**4 / 4, dt**3 / 2],
    [dt**3 / 2, dt**2]
])  # process noise covariance

R = np.array([[sigma_measure**2]])  # measurement noise covariance

# Initialize
x_true = np.array([[0.0],
                   [1.0]])  # true initial state (position, velocity)

x_est = np.array([[0.0],
                  [0.0]])   # estimated initial state

P = np.eye(2) * 1.0         # initial covariance

# Plotting arrays
true_positions = []
measured_positions = []
estimated_positions = []

# Simulation loop
for k in range(num_steps):

    # True system evolution
    a = 2.0  # constant acceleration

    process_noise = np.random.multivariate_normal(
        [0.1, 0],
        Q
    ).reshape(2, 1)

    x_true = A @ x_true + B * a + process_noise

    # Noisy measurement
    measurement_noise = np.random.normal(
        0,
        sigma_measure
    )

    z = H @ x_true + measurement_noise

    # --------------------------------------------------
    # Kalman Filter: Prediction only
    # --------------------------------------------------

    # 1. Predict state
    x_pred = A @ x_est + B * a

    # 2. Predict covariance
    P_pred = A @ P @ A.T + Q

    # --------------------------------------------------
    # No measurement correction
    # --------------------------------------------------

    # Normally, the Kalman gain and measurement update
    # would be computed here. For Part (f), we ignore
    # the measurement and keep the predicted state.
    x_est = x_pred
    P = P_pred

    # Save plotting arrays
    true_positions.append(
        x_true[0, 0]
    )

    measured_positions.append(
        z[0, 0]
    )

    estimated_positions.append(
        x_est[0, 0]
    )

# Plot
t = np.arange(num_steps) * dt

plt.figure(figsize=(10, 5))

plt.plot(
    t,
    true_positions,
    'g-',
    label='True Position',
    linewidth=2
)

plt.plot(
    t,
    measured_positions,
    'b*',
    label='Measured (Noisy)'
)

plt.plot(
    t,
    estimated_positions,
    'r.',
    label='Prediction Only (No Measurement Correction)'
)

plt.xlabel('Time [s]')
plt.ylabel('Position')

plt.title(
    '1D Kalman Filter Simulation Without Measurement Correction'
)

plt.legend()
plt.grid(True)

plt.show()
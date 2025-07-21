using UnityEngine;
/* this class stores helper functions for calculating physics equations */
public class PhysicsCalculator
{

    // Kinetic Energy = (1/2) * m * v^2
    public static float CalculateKineticEnergy(float mass, float velocity)
    {
        return 0.5f * mass * velocity * velocity;
    }

    // Momentum = m * v
    public static float CalculateMomentum(float mass, float velocity)
    {
        return mass * velocity;
    }

    // Impulse = ΔMomentum = m * (v_final - v_initial)
    public static float CalculateImpulse(float mass, float initialVelocity, float finalVelocity)
    {
        return mass * (finalVelocity - initialVelocity);
    }

    // Force = Impulse / Δt
    public static float CalculateImpactForce(float impulse, float time)
    {
        return impulse / time;
    }

    // Final velocity (1D) after elastic collision
    public static float CalculateElasticFinalVelocity(float m1, float v1, float m2, float v2)
    {
        return ((m1 - m2) / (m1 + m2)) * v1 + ((2 * m2) / (m1 + m2)) * v2;
    }

    // Final velocity (1D) after perfectly inelastic collision (they stick together)
    public static float CalculateInelasticFinalVelocity(float m1, float v1, float m2, float v2)
    {
        return (m1 * v1 + m2 * v2) / (m1 + m2);
    }

    // Total kinetic energy of a 2-object system
    public static float TotalKineticEnergy(float m1, float v1, float m2, float v2)
    {
        return CalculateKineticEnergy(m1, v1) + CalculateKineticEnergy(m2, v2);
    }

    // Total momentum of a 2-object system
    public static float TotalMomentum(float m1, float v1, float m2, float v2)
    {
        return CalculateMomentum(m1, v1) + CalculateMomentum(m2, v2);
    }
}

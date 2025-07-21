using UnityEngine;

public class CarColllisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");

        float m1 = CrashSettings.CarOneMass;
        float v1_initial = CrashSettings.CarOneInitialVelocity;
        float ke1_initial = PhysicsCalculator.CalculateKineticEnergy(m1, v1_initial);
        float p1_initial = PhysicsCalculator.CalculateMomentum(m1, v1_initial);

        Debug.Log($"[Before Collision] Car1 KE: {ke1_initial} J, Momentum: {p1_initial} kg·m/s car1 speed: {v1_initial} car1 mass: {m1}");

        float m2 = 0f, v2_initial = 0f, ke2_initial = 0f, p2_initial = 0f;

        if (CrashSettings.SceneType == 1)
        {
            m2 = CrashSettings.CarTwoMass;
            v2_initial = CrashSettings.CarTwoInitialVelocity;
            ke2_initial = PhysicsCalculator.CalculateKineticEnergy(m2, v2_initial);
            p2_initial = PhysicsCalculator.CalculateMomentum(m2, v2_initial);

            Debug.Log($"[Before Collision] Car2 KE: {ke2_initial} J, Momentum: {p2_initial} kg·m/s");
            Debug.Log($"[Before Collision] Total KE: {ke1_initial + ke2_initial} J, Total Momentum: {p1_initial + p2_initial} kg·m/s");
        }

        // Handle physics results after collision
        float v1_final = 0f;
        float v2_final = 0f;

        if (CrashSettings.SceneType == 0)
        {
            // Car hits wall — assume wall is infinite mass => Car1 bounces back or stops
            if (CrashSettings.IsElastic)
            {
                v1_final = -v1_initial;
            }
            else
            {
                v1_final = 0f;
            }

            float p1_final = PhysicsCalculator.CalculateMomentum(m1, v1_final);
            float ke1_final = PhysicsCalculator.CalculateKineticEnergy(m1, v1_final);

            Debug.Log($"[After Collision] Car1 KE: {ke1_final} J, Momentum: {p1_final} kg·m/s");
        }
        else
        {
            // Car vs Car
            if (CrashSettings.IsElastic)
            {
                v1_final = PhysicsCalculator.CalculateElasticFinalVelocity(m1, v1_initial, m2, -v2_initial);
                v2_final = PhysicsCalculator.CalculateElasticFinalVelocity(m2, -v2_initial, m1, v1_initial);
            }
            else
            {
                float v_final = PhysicsCalculator.CalculateInelasticFinalVelocity(m1, v1_initial, m2, -v2_initial);
                v1_final = v_final;
                v2_final = v_final;
            }

            float ke1_final = PhysicsCalculator.CalculateKineticEnergy(m1, v1_final);
            float ke2_final = PhysicsCalculator.CalculateKineticEnergy(m2, v2_final);
            float p1_final = PhysicsCalculator.CalculateMomentum(m1, v1_final);
            float p2_final = PhysicsCalculator.CalculateMomentum(m2, v2_final);

            Debug.Log($"[After Collision] Car1 KE: {ke1_final} J, Momentum: {p1_final} kg·m/s, Final Velocity: {v1_final}");
            Debug.Log($"[After Collision] Car2 KE: {ke2_final} J, Momentum: {p2_final} kg·m/s, Final Velocity: {v2_final}");
            Debug.Log($"[After Collision] Total KE: {ke1_final + ke2_final} J, Total Momentum: {p1_final + p2_final} kg·m/s");
        }
    }
}

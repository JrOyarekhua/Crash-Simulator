using UnityEngine;

/* this class is the class to handle object creation and apply input settings */

public class CrashSceneManager : MonoBehaviour
{
    
    public GameObject carPrefab;
    public GameObject wallPrefab;
    public GameObject car1;
    public GameObject car2;
    public Rigidbody2D carOneRb;
    public Rigidbody2D carTwoRb;
    public PhysicsMaterial2D elasticMat;
    public PhysicsMaterial2D inelasticMat;
    public float v1;
    public float v2;
    public float m1;
    public float m2;
    public bool hasCollided;
    public bool isBraking;

    /* function to spawn objects */
    public void spawnObjects()
    {
        car1 = Instantiate(carPrefab, new Vector2(-12, 0), Quaternion.Euler(0,0,-90));
        car1.name = "Car1";
        carOneRb = car1.GetComponent<Rigidbody2D>();
        carOneRb.mass = CrashSettings.CarOneMass;
        Debug.Log(carOneRb.mass);

        Collider2D car1Collider = car1.GetComponent<Collider2D>();

        car1Collider.sharedMaterial = CrashSettings.IsElastic ? elasticMat : inelasticMat;
        Debug.Log("physics material initialized !");

        if (CrashSettings.SceneType != 0)
        {
            car2 = Instantiate(carPrefab, new Vector2(12, 0), Quaternion.Euler(0, 0, 90));
            car2.name = "car2";
            carTwoRb = car2.GetComponent<Rigidbody2D>();
            carTwoRb.mass = CrashSettings.CarTwoMass;
            m2 = CrashSettings.CarTwoMass; 

            Collider2D col2 = car2.GetComponent<Collider2D>();
            if (col2 != null)
            {
                col2.sharedMaterial = CrashSettings.IsElastic ? elasticMat : inelasticMat;
                Debug.Log("physics material initialized !");
            }
        }
        else
        {
            GameObject wall = Instantiate(wallPrefab, new Vector2(12, 0), Quaternion.Euler(0, 0, 90));
        }
        

        
    }

 
    /* apply physics to car(s) and run */
    public void run()
    {
        if (CrashSettings.SceneType == 0)
        {
            // apply the linear velocity towards the wall 
            carOneRb.linearVelocity = new Vector2(CrashSettings.CarOneInitialVelocity, 0);
            v1 = CrashSettings.CarOneInitialVelocity;
        }
        else
        {
            // apply linear velocities towards the each other
            Debug.Log("car 2 initial velocity: " + CrashSettings.CarTwoInitialVelocity);
            carOneRb.linearVelocity = new Vector2(CrashSettings.CarOneInitialVelocity, 0);
            carTwoRb.linearVelocity = new Vector2(-CrashSettings.CarTwoInitialVelocity, 0);
            v2 = -CrashSettings.CarTwoInitialVelocity;
           
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision !!!");
        if (CrashSettings.SceneType == 1)
        {
            float v1 = carOneRb.linearVelocityX;
            float v2 = carTwoRb.linearVelocityX;
            float m1 = carOneRb.mass;
            float m2 = carTwoRb.mass;

            float newV1, newV2, newKE;

            if (CrashSettings.IsElastic)
            {
                newV1 = PhysicsCalculator.CalculateElasticFinalVelocity(m1, m2, v1, v2);
                newV2 = PhysicsCalculator.CalculateElasticFinalVelocity(m2, m1, v2, v1);
                newKE = PhysicsCalculator.CalculateKineticEnergy(m1, v1);
                // get the label and calculate the new velocity

            }
            else
            {
                float sharedV = PhysicsCalculator.CalculateElasticFinalVelocity(m1, m2, v1, v2);
                newV1 = newV2 = sharedV;
                // get the velocity and calculate the final velocity 
            }

            carOneRb.linearVelocity = new Vector2(0, newV1);
            carTwoRb.linearVelocity = new Vector2(0, newV2);

        }
    }
}

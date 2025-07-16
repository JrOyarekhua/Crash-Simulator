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


    /* function to spawn objects */
    public void spawnObjects()
    {
        car1 = Instantiate(carPrefab, new Vector2(-12, 0), Quaternion.Euler(0,0,-90));
        carOneRb = car1.GetComponent<Rigidbody2D>();
        carOneRb.mass = CrashSettings.CarOneMass;

        Collider2D car1Collider = car1.GetComponent<Collider2D>();
        car1Collider.sharedMaterial = CrashSettings.IsElastic ? elasticMat : inelasticMat;

        if (CrashSettings.SceneType != 0)
        {
            car2 = Instantiate(carPrefab, new Vector2(12, 0), Quaternion.Euler(0, 0, 90));
            carTwoRb = car2.GetComponent<Rigidbody2D>();
            carTwoRb.mass = CrashSettings.CarTwoMass;

            Collider2D col2 = car2.GetComponent<Collider2D>();
            if (col2 != null)
            {
                col2.sharedMaterial = CrashSettings.IsElastic ? elasticMat : inelasticMat;
            }
        }


        if (CrashSettings.SceneType == 0)
        {
            GameObject wall = Instantiate(wallPrefab, new Vector2(12, 0), Quaternion.Euler(0,0,90));

        }
        else
        {
            car2 = Instantiate(carPrefab, new Vector2(12, 0), Quaternion.Euler(0,0,90));
            carTwoRb = car2.GetComponent<Rigidbody2D>();
            carTwoRb.mass = CrashSettings.CarTwoMass;
        }
    }

 
    /* apply physics to car(s) and run */
    public void run()
    {
        if (CrashSettings.SceneType == 0)
        {
            // apply the linear velocity towards the wall 
            carOneRb.linearVelocity = new Vector2(CrashSettings.CarOneInitialVelocity, 0);
        }
        else
        {
            // apply linear velocities towards the each other
            Debug.Log("car 2 initial velocity: " + CrashSettings.CarTwoInitialVelocity);
            carOneRb.linearVelocity = new Vector2(CrashSettings.CarOneInitialVelocity, 0);
            carTwoRb.linearVelocity = new Vector2(-CrashSettings.CarTwoInitialVelocity, 0);
           
        }
    }
}

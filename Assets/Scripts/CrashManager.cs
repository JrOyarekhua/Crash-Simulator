using UnityEngine;

public class CrashManager : MonoBehaviour
{
    public CrashSceneManager crashManager;
    public MainMenuController UIcontroller;
   

    private float brakeTimer = 0f;
    public float brakeDuration = 2f;
    private bool isBraking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIcontroller.run();
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn objects after UI is hidden
        if (!UIcontroller.gameObject.activeSelf && !CrashSettings.hasSpawned)
        {
            crashManager.spawnObjects();
            crashManager.run();
            CrashSettings.hasSpawned = true;

            // If inelastic, start brake countdown
            if (!CrashSettings.IsElastic)
                isBraking = true;
                
        }

        
    }


    public void toggleUI()
    {
        CrashSettings.toggleUI = !CrashSettings.toggleUI;
    }
}

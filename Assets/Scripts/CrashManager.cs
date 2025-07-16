using UnityEngine;

public class CrashManager : MonoBehaviour
{
    public CrashSceneManager crashManager;
    public MainMenuController UIcontroller; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIcontroller.run();
    }

    // Update is called once per frame
    void Update()
    {
        // spawn objects the UI gets disabled (e.g. via gameObject.SetActive(false))
        if (!UIcontroller.gameObject.activeSelf && !CrashSettings.hasSpawned)
        {
            crashManager.spawnObjects();
            crashManager.run();
            CrashSettings.hasSpawned = true;
        }


    }
    public void toggleUI()
    {
        CrashSettings.toggleUI = !CrashSettings.toggleUI;
    }
}

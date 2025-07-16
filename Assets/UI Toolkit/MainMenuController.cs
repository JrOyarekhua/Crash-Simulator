using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
public class MainMenuController : MonoBehaviour
{   
    private VisualElement root; 
    List<VisualElement> screens = new List<VisualElement>();
    
    int currentIndex = 0;

    //void OnEnable(){
       
        
    //}

    public void run()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        // Initialize screens
        screens.Add(root.Q("start_screen"));
        screens.Add(root.Q("scene_screen"));
        screens.Add(root.Q("car_screen"));

        foreach (var screen in screens)
            Debug.Log($"Screen loaded: {screen.name}");

        ShowScreen(currentIndex);
        SetButtons();


    }

    public void ShowScreen(int index)
    {
        if (index < 0 || index >= screens.Count) return;

        for (int i = 0; i < screens.Count; i++)
            screens[i].style.display = i == index ? DisplayStyle.Flex : DisplayStyle.None;

        currentIndex = index;
    }
     public void NextScreen()
    {
        int nextIndex = (currentIndex + 1) % screens.Count;
        ShowScreen(nextIndex);
    }

    public void PreviousScreen()
    {
        int prevIndex = (currentIndex - 1 + screens.Count) % screens.Count;
        ShowScreen(prevIndex);
    }
    /* function to set up buttons for navigation*/
    public void SetButtons(){
        // start btn logic 
        VisualElement startBtn = screens[0].Q<Button>("start_button");
        startBtn.RegisterCallback<ClickEvent>( evt => {
            Debug.Log(startBtn);
            NextScreen();
        });

        // crash btn logic 
        VisualElement carWallBtn = screens[1].Q<Button>("car_wall_btn");
        VisualElement carCarBtn = screens[1].Q<Button>("car_car_btn");

        carWallBtn.RegisterCallback<ClickEvent>( evt => {
            Debug.Log("btn clicked");
            CrashSettings.SceneType = 0; 
            NextScreen();
        });

        carCarBtn.RegisterCallback<ClickEvent>( evt => {
            Debug.Log("btn clicked");
            CrashSettings.SceneType = 1;
            NextScreen();
        });

        // 
        VisualElement startSceneBtn = screens[2].Q<Button>("scene_start_btn");
        startSceneBtn.RegisterCallback<ClickEvent>(evt =>
        {
            Debug.Log("starting simulation...");
            SetInput(CrashSettings.SceneType == 1);
            gameObject.SetActive(false);
            
        });



    }
    /* function to handle input fields*/
   public void SetInput(bool carActive){
        FloatField carOneMass = screens[2].Q<FloatField>("car_one_mass");
        FloatField carOneSpeed = screens[2].Q<FloatField>("car_one_speed");

        CrashSettings.CarOneMass = carOneMass.value;
        CrashSettings.CarOneInitialVelocity = carOneSpeed.value;

        
        // get input fields
        if (carActive)
        {
            FloatField carTwoMassInput = screens[2].Q<FloatField>("car_two_mass");
            FloatField carTwoSpeedInput = screens[2].Q<FloatField>("car_two_speed");
            Debug.Log("setting car 2 initial velocity...");
            CrashSettings.CarTwoMass = carTwoMassInput.value;
            CrashSettings.CarTwoInitialVelocity = carTwoSpeedInput.value;
            Debug.Log(CrashSettings.CarTwoInitialVelocity); 

        };
    }

    

}
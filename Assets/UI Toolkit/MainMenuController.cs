using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class MainMenuController : MonoBehaviour
{
    private VisualElement root;
    List<VisualElement> screens = new List<VisualElement>();
    int currentIndex = 0;

    void OnEnable()
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

        // Hide Car 2 inputs by default until scene type selected
        ToggleCarTwoInput(false);
    }

    public void ShowScreen(int index)
    {
        if (index < 0 || index >= screens.Count) return;

        for (int i = 0; i < screens.Count; i++)
            screens[i].style.display = i == index ? DisplayStyle.Flex : DisplayStyle.None;

        currentIndex = index;
    }

    public void HideScreens()
    {
        foreach (var screen in screens)
        {
            screen.style.display = DisplayStyle.None;
        }
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

    public void SetButtons()
    {
        // Start button logic
        VisualElement startBtn = screens[0].Q<Button>("start_button");
        if (startBtn != null)
        {
            startBtn.RegisterCallback<ClickEvent>(evt =>
            {
                Debug.Log("Start button clicked");
                NextScreen();
            });
        }

        // Crash type selection buttons
        Button carWallBtn = screens[1].Q<Button>("car_wall_btn");
        Button carCarBtn = screens[1].Q<Button>("car_car_btn");

        if (carWallBtn != null)
        {
            carWallBtn.RegisterCallback<ClickEvent>(evt =>
            {
                Debug.Log("Car vs Wall selected");
                CrashSettings.SceneType = 0;
                ToggleCarTwoInput(false);
                NextScreen();
            });
        }

        if (carCarBtn != null)
        {
            carCarBtn.RegisterCallback<ClickEvent>(evt =>
            {
                Debug.Log("Car vs Car selected");
                CrashSettings.SceneType = 1;
                ToggleCarTwoInput(true);
                NextScreen();
            });
        }

        // Start Scene Logic 
        Button startSceneBtn = screens[2].Q<Button>("scene_start_btn");
        startSceneBtn.RegisterCallback<ClickEvent>(evt => {
            // set values 
            FloatField carOneMass = screens[2].Q<FloatField>("car_one_mass");
            FloatField carOneSpeed = screens[2].Q<FloatField>("car_one_speed");
            CrashSettings.CarOneMass = carOneMass.value;
            CrashSettings.CarOneInitialVelocity = carOneSpeed.value;
            if(CrashSettings.SceneType == 1)
            {
                FloatField carTwoMass = screens[2].Q<FloatField>("car_two_mass");
                FloatField carTwoSpeed = screens[2].Q<FloatField>("car_two-speed");
                CrashSettings.CarTwoMass = carTwoMass.value;
                CrashSettings.CarTwoInitialVelocity = carTwoMass.value;

            };
            Debug.Log("Values Set");
            gameObject.SetActive(false);
        });


    }

    private void ToggleCarTwoInput(bool isVisible)
    {
        VisualElement carTwoWrapper = screens[2].Q("car_two_input");
        if (carTwoWrapper != null)
        {
            carTwoWrapper.style.display = isVisible ? DisplayStyle.Flex : DisplayStyle.None;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionsMenuScript : MonoBehaviour
{
    private VisualElement root;
    private Button BackButton;

    private Button GraphicsButton;
    private Button GameplayButton;
    private Button SoundButton;

    private VisualTreeAsset GraphicsSection;
    private VisualTreeAsset GameplaySection;
    private VisualTreeAsset SoundSection;
    private TemplateContainer currentSection;

    private UIManager UImanager;
    private PauseControl pauseControl; // PauseControl.CanPause = false

    private void Awake()
    {
        UImanager = GameObject.Find("UIManager").GetComponent<UIManager>();
        pauseControl = GameObject.Find("Player").GetComponent<PauseControl>();
    }
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        BackButton = root.Q<Button>("back_button");

        // currentSection = GraphicsSection.Instantiate(Application.dataPath + "");

        GraphicsButton = root.Q<Button>("graphics_button");
        GameplayButton = root.Q<Button>("gameplay_button");
        SoundButton = root.Q<Button>("sound_button");

        BackButton.clicked += () => BackButton_Clicked();
        GraphicsButton.clicked += () => GraphicsSection_Chosen();
        GameplayButton.clicked += () => GameplaySection_Chosen();
        SoundButton.clicked += () => SoundSection_Chosen();
    }

    void BackButton_Clicked()
    {
        pauseControl.CanPause = true;
        UImanager.LoadUI("HUD");
        UImanager.LoadUI("PauseUI");
        UImanager.UnloadUI("OptionsUI");
    }

    void GraphicsSection_Chosen() // Load Graphics section
    {

    }

    void GameplaySection_Chosen() // Load Gameplay section
    {

    }

    void SoundSection_Chosen() // Load Sound section
    {

    }
}

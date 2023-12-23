using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionsMenuScript : MonoBehaviour
{
    private VisualElement root;
    private Button CancelButton;

    private Button GraphicsButton;
    private Button GameplayButton;
    private Button SoundButton;

    private VisualTreeAsset GraphicsSection;
    private VisualTreeAsset GameplaySection;
    private VisualTreeAsset SoundSection;
    private TemplateContainer currentSection;


    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        CancelButton = root.Q<Button>("cancel_button");

        currentSection = GraphicsSection.Instantiate(Application.dataPath + "");

        GraphicsButton = root.Q<Button>("graphics_button");
        GameplayButton = root.Q<Button>("gameplay_button");
        SoundButton = root.Q<Button>("sound_button");


        GraphicsButton.clicked += GraphicsSectionChosen;
        GameplayButton.clicked += GameplaySectionChosen;
        SoundButton.clicked += SoundSectionChosen;
    }

    void GraphicsSectionChosen() // Load Graphics section
    {

    }

    void GameplaySectionChosen() // Load Gameplay section
    {

    }

    void SoundSectionChosen() // Load Sound section
    {

    }
}

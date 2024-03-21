using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUDScript : MonoBehaviour
{
    PlayerInstance player;

    public VisualElement root;
    public SkillManager sm;

    public Button Skill_1;
    public Button Skill_2;
    public Button Skill_3;

    public ProgressBar Health_bar;
    public ProgressBar Energy_bar;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerInstance>();
        sm = GameObject.Find("Player").GetComponent<SkillManager>();
    }

    private void OnEnable()
    {
        //Инициализация UI
        root = GetComponent<UIDocument>().rootVisualElement;

        Skill_1 = root.Q<Button>("skill_1");
        Skill_2 = root.Q<Button>("skill_2");
        Skill_3 = root.Q<Button>("skill_3");

        Health_bar = root.Q<ProgressBar>("health_bar");
        Energy_bar = root.Q<ProgressBar>("energy_bar");

        // -----
        Skill_1.text = "";
        Skill_2.text = "";
        Skill_3.text = "";
    }

    private void Update()
    {
        // Skill icons update
        try
        {
            Skill_1.style.backgroundImage = new StyleBackground(sm.GetSkillFromHotkey(0).Icon);
        }
        catch
        {
            // Do nothing about it!
        }
        try
        {
            Skill_2.style.backgroundImage = new StyleBackground(sm.GetSkillFromHotkey(1).Icon);
        }
        catch
        {
            // Do nothing about it, we don't care!
        }
        try
        {
            Skill_3.style.backgroundImage = new StyleBackground(sm.GetSkillFromHotkey(2).Icon);
        }
        catch
        {
            // Nope, don't care at all!
        }

        // ProgressBars update

        Health_bar.value = player.Health;
        Energy_bar.value = player.Energy;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUDScript : MonoBehaviour
{
    Player player;

    public VisualElement root;

    public Button Skill_1;
    public Button Skill_2;
    public Button Skill_3;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnEnable()
    {
        //Инициализация UI
        root = GetComponent<UIDocument>().rootVisualElement;

        Skill_1 = root.Q<Button>("skill_1");
        Skill_2 = root.Q<Button>("skill_2");
        Skill_3 = root.Q<Button>("skill_3");

        // -----
        Skill_1.text = "";
        Skill_2.text = "";
        Skill_3.text = "";
    }

    private void Update()
    {
        Skill_1.style.backgroundImage = new StyleBackground(player.skillSlots[0].Icon);
        Skill_2.style.backgroundImage = new StyleBackground(player.skillSlots[1].Icon);
        Skill_3.style.backgroundImage = new StyleBackground(player.skillSlots[2].Icon);
    }
}

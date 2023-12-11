using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUDScript : MonoBehaviour
{
    public VisualElement root;

    public Button Skill_1;
    public Button Skill_2;
    public Button Skill_3;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        Skill_1 = root.Q<Button>("skill_1");
        Skill_2 = root.Q<Button>("skill_2");
        Skill_3 = root.Q<Button>("skill_3");
    }
}

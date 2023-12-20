using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionsMenuScript : MonoBehaviour
{
    VisualElement root;
    Button CancelButton;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        CancelButton = root.Q<Button>("cancel_button");

    }
}

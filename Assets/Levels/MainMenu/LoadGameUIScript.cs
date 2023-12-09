using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadGameUIScript : MonoBehaviour
{

    private VisualElement root;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

    }
}

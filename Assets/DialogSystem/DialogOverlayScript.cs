using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogOverlayScript : MonoBehaviour
{
    public VisualElement root;

    public Label characterName;
    public Label characterSpeech;
    public Label characterImage;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        characterName = root.Q<Label>("characterName");
        characterSpeech = root.Q<Label>("characterSpeech");
        characterImage = root.Q<Label>("characterImage");
    }
}

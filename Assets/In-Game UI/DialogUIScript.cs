using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogUIScript : MonoBehaviour
{
    public VisualElement root;

    public Label characterName;
    public Label characterSpeech;
    public VisualElement characterImage;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        characterName = root.Q<Label>("characterName");
        characterSpeech = root.Q<Label>("characterSpeech");
        characterImage = root.Q<VisualElement>("characterImage");
    }

    public void SetCharacterName(string name)
    {
        characterName.text = name;
    }

    public void SetCharacterText(string line)
    {
        characterSpeech.text = line;
    }

    public void SetCharacterImage(Sprite sprite)
    {
        characterImage.style.backgroundImage = Background.FromSprite(sprite);
        //Должна вставляться картинка... (добавить позже)
    }
}

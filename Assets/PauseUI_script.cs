using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseUI_script : MonoBehaviour
{
    private VisualElement root; // ������ � UI
    public void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        //������ � �������
        Button ButtonResume = root.Q<Button>("resume_button");
        Button ButtonOptions = root.Q<Button>("options_button");
        Button ButtonExit = root.Q<Button>("exit_button");

        //��������� �������
        ButtonResume.clicked += () => PauseControl.Pause();
    }
}

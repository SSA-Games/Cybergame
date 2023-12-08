// PauseControl.cs
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseControl : MonoBehaviour
{
    private static PauseUI_script pauseUIObject;

    void Start()
    {
        pauseUIObject = GetComponent<PauseUI_script>();
    }

    public static void Pause(PauseUI_script uiObject)
    {
        Time.timeScale = 0f;
        if (uiObject != null)
        {
            uiObject.ShowPauseMenu();
        }
    }
}

// PauseUI_script.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseUI_script : MonoBehaviour
{
    private VisualTreeAsset visualTreeAsset; // ��������� ���� ��� �������� ������� UI
    private VisualElement root;

    void Awake()
    {
        visualTreeAsset = Resources.Load<VisualTreeAsset>("YourVisualTreeAssetName"); // �������� "YourVisualTreeAssetName" �� ����������� ��� ������ �������
    }

    public void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        // �������� UI �� VisualTreeAsset
        VisualElement ui = visualTreeAsset.CloneTree();
        root.Add(ui);

        // ������ � �������
        Button buttonResume = ui.Q<Button>("resume_button");
        Button buttonOptions = ui.Q<Button>("options_button");
        Button buttonExit = ui.Q<Button>("exit_button");

        // ��������� �������
        buttonResume.clicked += () => PauseControl.Pause(this);
    }

    public void ShowPauseMenu()
    {
        // ��� ��� ��� ����������� ���� �����
    }
}

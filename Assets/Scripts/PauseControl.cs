// PauseControl.cs
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseControl : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject PauseUIObject;
    public static bool isPaused = false; // ������ �����
=======
    private static PauseUI_script pauseUIObject;
>>>>>>> 7c7d8281d9e9f916e2aec4afdd46457d609efcac

    void Start()
    {
<<<<<<< HEAD
        //�������� ������� ����� ������ ����
        Pause();
        if (!isPaused)
        {
            PauseUIObject.SetActive(false);
        }
        else
        {
            PauseUIObject.SetActive(true);
        }
=======
        pauseUIObject = GetComponent<PauseUI_script>();
>>>>>>> 7c7d8281d9e9f916e2aec4afdd46457d609efcac
    }

    public static void Pause(PauseUI_script uiObject)
    {
        Time.timeScale = 0f;
        if (uiObject != null)
        {
<<<<<<< HEAD
            isPaused = true;
            Time.timeScale = 0f;
        }
        isPaused = false;
        Time.timeScale = 1f;
=======
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
>>>>>>> 7c7d8281d9e9f916e2aec4afdd46457d609efcac
    }
}

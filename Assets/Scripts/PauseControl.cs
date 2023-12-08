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
    private VisualTreeAsset visualTreeAsset; // Добавлено поле для хранения шаблона UI
    private VisualElement root;

    void Awake()
    {
        visualTreeAsset = Resources.Load<VisualTreeAsset>("YourVisualTreeAssetName"); // Замените "YourVisualTreeAssetName" на фактическое имя вашего ресурса
    }

    public void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        // Загрузка UI из VisualTreeAsset
        VisualElement ui = visualTreeAsset.CloneTree();
        root.Add(ui);

        // Доступ к кнопкам
        Button buttonResume = ui.Q<Button>("resume_button");
        Button buttonOptions = ui.Q<Button>("options_button");
        Button buttonExit = ui.Q<Button>("exit_button");

        // Обработка событий
        buttonResume.clicked += () => PauseControl.Pause(this);
    }

    public void ShowPauseMenu()
    {
        // Ваш код для отображения меню паузы
    }
}

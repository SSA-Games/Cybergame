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
    public static bool isPaused = false; // Статус паузы
=======
    private static PauseUI_script pauseUIObject;
>>>>>>> 7c7d8281d9e9f916e2aec4afdd46457d609efcac

    void Start()
    {
<<<<<<< HEAD
        //Проверка нажатия паузы каждый кадр
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
>>>>>>> 7c7d8281d9e9f916e2aec4afdd46457d609efcac
    }
}

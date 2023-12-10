using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Linq;

public class LoadGameUIScript : MonoBehaviour
{
    // Define visual elements
    private VisualElement root;
    private GroupBox SavesList;
    private GroupBox InfoList;
    private Button LoadButton;
    private Button DeleteButton;
    private Button CancelButton;

    private GameObject MainMenuUI;
    private GameObject LoadGameUI;
    private GameObject Player;

    private Button selectedSave;

    private void Awake()
    {
        MainMenuUI = FindObjectsOfType<GameObject>(true).Where(obj => obj.name == "MainMenuUI").ToArray()[0];
        LoadGameUI = FindObjectsOfType<GameObject>(true).Where(obj => obj.name == "LoadGameUI").ToArray()[0];
    }
    private void OnEnable()
    {
        // Получение доступа к UI
        root = GetComponent<UIDocument>().rootVisualElement;

        SavesList = root.Q<GroupBox>("saves_list");
        GroupBox InfoList = root.Q<GroupBox>("info_list");
        LoadButton = root.Q<Button>("load_button");
        DeleteButton = root.Q<Button>("delete_button");
        CancelButton = root.Q<Button>("cancel_button");

        // Загрузка сохранений в кнопки

        List<string> SaveNames = SaveLoadManager.GetSaveNames();
        for (int i = 0; i < SaveLoadManager.SavesCount(); i++)
        {
            Debug.Log("adding some buttons");
            AddSaveToList(SaveNames[i]);
        }

        // Обработка событий кнопок

        DeleteButton.clicked += () => DeleteButton_Clicked();
        LoadButton.clicked += () => LoadButton_Clicked();
        CancelButton.clicked += () => CancelButton_Clicked();
    }

    private void LoadButton_Clicked()
    {
        if (selectedSave != null)
        {
            //Найти выделенное сохранениe и загрузить
        }
    }

    private void DeleteButton_Clicked()
    {
        if (selectedSave != null)
        {
            selectedSave = null;
            RemoveSaveFromList(selectedSave);
        }
    }

    private void CancelButton_Clicked()
    {
        MainMenuUI.SetActive(true);
        gameObject.SetActive(false);
    }

    private void AddSaveToList(string name) //Добавляем сохранение в UI
    {
        Button Save = new Button();
        Save.text = name;
        Save.style.width = Length.Percent(100);
        Save.clicked += () =>
        {
            selectedSave = Save;
        };
    }
    private void RemoveSaveFromList(Button save) // Удаление сохранения из UI
    {
        foreach (Button save_button in SavesList.Children())
        {
            if (save_button == save)
            {
                save_button.SetEnabled(false);
            }
        }
    }
}

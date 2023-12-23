using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseUIScript: MonoBehaviour
{
    private VisualElement root; // Доступ к UI
    private GroupBox SavesList;
    private Label SaveStatusLabel;

    public GameObject OptionsUI; // UI Options prefab to create

    Button ButtonResume;
    Button ButtonOptions;
    Button ButtonExit;
    Button ButtonQuickSave;
    Button ButtonLoadSave;
    Button ButtonLoad;

    private GameObject Player;
    private UIManager uim;
    private Button selectedSave;
    private void Awake()
    {
        Player = GameObject.Find("Player");
        uim = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        //Доступ к UI
        ButtonResume = root.Q<Button>("resume_button");
        ButtonOptions = root.Q<Button>("options_button");
        ButtonExit = root.Q<Button>("exit_button");
        ButtonQuickSave = root.Q<Button>("quicksave_button");
        ButtonLoadSave = root.Q<Button>("loadsave_button");
        ButtonLoad = root.Q<Button>("load_button");
        ButtonOptions = root.Q<Button>("options_button");

        SavesList = root.Q<GroupBox>("saves_list");
        SaveStatusLabel = root.Q<Label>("savestatus_label");

        //Обработка событий
        ButtonResume.clicked += () => ResumeButton_Clicked();
        ButtonExit.clicked += () => ExitButton_Clicked();
        ButtonQuickSave.clicked += () => QuickSaveButton_Clicked();
        ButtonLoadSave.clicked += () => LoadSaveButton_Clicked();
        ButtonLoad.clicked += () => LoadButton_Clicked();
        ButtonOptions.clicked += () => OptionsButton_Clicked();
    }

    private void ResumeButton_Clicked()
    {
        Player.GetComponent<PauseControl>().SetPause(false);
    }

    private void OptionsButton_Clicked()
    {
        Instantiate(OptionsUI);
    }

    private void ExitButton_Clicked()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void QuickSaveButton_Clicked() //Вызываем логику быстрого сохранения и выводим сверху справа статус сохранения
    {
        SaveStatusLabel.style.display = DisplayStyle.Flex;
        string saveName = SaveLoadManager.QuickSave();
        SaveStatusLabel.text = "Successfully saved as " + saveName;
        StartCoroutine(PauseControl.waiter(3));
        SaveStatusLabel.style.display = DisplayStyle.None;
        SaveStatusLabel.text = "Saving...";
    }

    private void LoadSaveButton_Clicked()
    {
        SavesList.style.display = DisplayStyle.Flex;
        ButtonLoad.style.display = DisplayStyle.Flex;
        
        // Загрузка сохранений в кнопки

        List<string> SaveNames = SaveLoadManager.GetSaveNames();
        for (int i = 0; i < SaveLoadManager.SavesCount(); i++)
        {
            AddSaveToList(SaveNames[i]);
        }
    }

    private void LoadButton_Clicked()
    {
        SavesList.style.display = DisplayStyle.None;
        ButtonLoad.style.display = DisplayStyle.None;
        if (selectedSave != null)
        {
            SaveLoadManager.LoadSave(selectedSave.text); //Передаем название сохранения в метод для загрузки
        }
    }

    private void AddSaveToList(string name) //Добавляем сохранение в UI
    {
        Button Save = new Button();
        SavesList.Add(Save);
        Save.text = name.Substring(0, name.Length - 5);
        Save.style.width = Length.Percent(100);
        Save.clicked += () =>
        {
            Debug.Log("now selected button " + Save.text);
            selectedSave = Save;
        };
    }
}
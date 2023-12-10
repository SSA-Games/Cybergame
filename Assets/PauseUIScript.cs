using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseUIScript: MonoBehaviour
{
    private VisualElement root; // Доступ к UI
    private Label SaveStatusLabel;
    GameObject Player;
    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    public void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        //Доступ к UI
        Button ButtonResume = root.Q<Button>("resume_button");
        Button ButtonOptions = root.Q<Button>("options_button");
        Button ButtonExit = root.Q<Button>("exit_button");
        Button ButtonQuickSave = root.Q<Button>("quicksave_button");

        SaveStatusLabel = root.Q<Label>("savestatus_label");

        //Обработка событий
        ButtonResume.clicked += ()=> PauseButton_Clicked();
        ButtonExit.clicked += () => ExitButton_Clicked();
        ButtonQuickSave.clicked += () => QuickSaveButton_Clicked();
    }

    private void PauseButton_Clicked()
    {
        Player.GetComponent<PauseControl>().isPaused = false;
        Time.timeScale = 1f;
    }

    private void ExitButton_Clicked()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void QuickSaveButton_Clicked()
    {
        SaveStatusLabel.style.display = DisplayStyle.Flex;
        Player.GetComponent<SaveLoadManager>().QuickSave();
        SaveStatusLabel.style.display = DisplayStyle.None;
    }
}
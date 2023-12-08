using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseUIScript: MonoBehaviour
{
    private VisualElement root; // Доступ к UI
    public void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        //Доступ к кнопкам
        Button ButtonResume = root.Q<Button>("resume_button");
        Button ButtonOptions = root.Q<Button>("options_button");
        Button ButtonExit = root.Q<Button>("exit_button");

        //Обработка событий
        ButtonResume.clicked += ()=>PauseButton_Clicked();
        ButtonExit.clicked += () => ExitButton_Clicked();
    }

    private void PauseButton_Clicked()
    {
        PauseControl.isPaused = false;
        Time.timeScale = 1f;
    }

    private void ExitButton_Clicked()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
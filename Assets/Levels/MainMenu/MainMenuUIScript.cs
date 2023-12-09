using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUIScript : MonoBehaviour
{
    private VisualElement root;

    //Обработка событий
    private void OnEnable()
    {
        // Доступ к UI
        root = GetComponent<UIDocument>().rootVisualElement;

        Button NewGameButton = root.Q<Button>("new_game_button");
        Button LoadGameButton = root.Q<Button>("load_game_button");
        Button OptionsButton = root.Q<Button>("options_button");
        Button ExitButton = root.Q<Button>("exit_button");

        // Обработка событий

        NewGameButton.clicked += () => NewGameButton_Clicked();
        LoadGameButton.clicked += () => LoadGameButton_Clicked();
        OptionsButton.clicked += () => OptionsButton_Clicked();
        ExitButton.clicked += () => ExitButton_Clicked();
    }

    private void NewGameButton_Clicked()
    {

    }

    private void LoadGameButton_Clicked()
    {

    }

    private void OptionsButton_Clicked()
    {

    }

    private void ExitButton_Clicked()
    {
        Debug.Log("wow");
        Application.Quit();
    }
}

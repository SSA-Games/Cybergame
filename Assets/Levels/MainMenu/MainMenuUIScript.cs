using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Linq;

public class MainMenuUIScript : MonoBehaviour
{
    private VisualElement root;
    private GameObject LoadGameUI;

    private void Start()
    {
        LoadGameUI = FindObjectsOfType<GameObject>(true).Where(obj => obj.name == "LoadGameUI").ToArray()[0];
        Debug.Log("Pls tell me you found the object  " + LoadGameUI.name);
    }
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
        // ПОТОМ НУЖНО БУДЕТ ДОРАБОТАТЬ, НО ПОКА ОСТАВИМ ТАК ДЛЯ ПРОСТОТЫ ДЕБАГА
        SceneManager.LoadScene("Level_1");
    }

    private void LoadGameButton_Clicked()
    {
        LoadGameUI.SetActive(true);
        gameObject.SetActive(false);
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

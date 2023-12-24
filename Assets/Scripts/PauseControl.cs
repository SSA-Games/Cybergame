using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public UIManager UImanager;
    public bool CanPause = true; // Может ли игрок нажать на паузу сейчас

    private bool isPaused = false; // Статус паузы


    private void Awake()
    {
        UImanager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    void Update()
    {
        //Проверка нажатия ESC
        if (Input.GetKeyDown(KeyCode.Escape) && CanPause == true ) // Если игрок занят, клавиша не работает
        {
            SetPause(!isPaused);
        }
    }


    public void SetPause(bool flag) //Логика переключения паузы
    {
        if (flag)
        {
            isPaused = true;
            Time.timeScale = 0f;
            UImanager.LoadUI("PauseUI");
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
            UImanager.UnloadUI("PauseUI");
        }
    }

    public static IEnumerator waiter(int seconds)  //Магический код для того, чтобы подождать три секунды (Unity moment)
    {
        yield return new WaitForSecondsRealtime(seconds);
    }

}
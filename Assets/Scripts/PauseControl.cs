using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public GameObject PauseUIObject;
    public bool isPaused = false; // Статус паузы

    void Update()
    {
        //Проверка нажатия паузы каждый кадр
        PauseCheck();
        PauseUIObject.SetActive(isPaused);
    }

    public void PauseCheck() //Логика паузы
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0f;
            }
            else
            {
                isPaused = false;
                Time.timeScale = 1f;
            }
        }
    }

    public static IEnumerator waiter(int seconds)  //Магический код для того, чтобы подождать три секунды (Unity moment)
    {
        yield return new WaitForSecondsRealtime(seconds);
    }

}
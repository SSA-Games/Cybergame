using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public UIManager uim;
    private bool isPaused = false; // Статус паузы

    private void Awake()
    {
        uim = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    void Update()
    {
        //Проверка нажатия ESC
        if (Input.GetKeyDown(KeyCode.Escape))
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
            uim.LoadUI("PauseUI");
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
            uim.UnloadUI("PauseUI");
        }
    }

    public static IEnumerator waiter(int seconds)  //Магический код для того, чтобы подождать три секунды (Unity moment)
    {
        yield return new WaitForSecondsRealtime(seconds);
    }

}
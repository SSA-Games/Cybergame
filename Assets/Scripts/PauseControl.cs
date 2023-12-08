using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public GameObject PauseUIObject;
    public static bool isPaused = false; // ������ �����

    void Update()
    {
        //�������� ������� ����� ������ ����
        Pause();
        if (!isPaused)
        {
            PauseUIObject.SetActive(false);
        }
        else
        {
            PauseUIObject.SetActive(true);
        }
    }

    public static void Pause() //������ �����
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            Time.timeScale = 0f;
        }
        isPaused = false;
        Time.timeScale = 1f;
    }
}

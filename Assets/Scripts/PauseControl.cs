using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public GameObject PauseUIObject;
    public static bool isPaused; // ������ �����

    void Update()
    {
        //�������� ������� ����� ������ ����
        Pause();
    }

    public static void Pause() //������ �����
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUIObject.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
        PauseUIObject.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}

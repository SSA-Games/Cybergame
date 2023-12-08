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
        PauseCheck();
        PauseUIObject.SetActive(isPaused);
    }

    public static void PauseCheck() //������ �����
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
}
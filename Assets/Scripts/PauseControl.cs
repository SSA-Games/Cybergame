using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public UIManager uim;
    private bool isPaused = false; // ������ �����

    private void Awake()
    {
        uim = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    void Update()
    {
        //�������� ������� ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause(!isPaused);
        }
    }


    public void SetPause(bool flag) //������ ������������ �����
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

    public static IEnumerator waiter(int seconds)  //���������� ��� ��� ����, ����� ��������� ��� ������� (Unity moment)
    {
        yield return new WaitForSecondsRealtime(seconds);
    }

}
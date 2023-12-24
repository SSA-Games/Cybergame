using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public UIManager UImanager;
    public bool CanPause = true; // ����� �� ����� ������ �� ����� ������

    private bool isPaused = false; // ������ �����


    private void Awake()
    {
        UImanager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    void Update()
    {
        //�������� ������� ESC
        if (Input.GetKeyDown(KeyCode.Escape) && CanPause == true ) // ���� ����� �����, ������� �� ��������
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
            UImanager.LoadUI("PauseUI");
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
            UImanager.UnloadUI("PauseUI");
        }
    }

    public static IEnumerator waiter(int seconds)  //���������� ��� ��� ����, ����� ��������� ��� ������� (Unity moment)
    {
        yield return new WaitForSecondsRealtime(seconds);
    }

}
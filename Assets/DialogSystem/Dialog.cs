using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class Dialog 
{
    /* ������ ������� ��������� ��� ��������� �������.
    * ��� �������� � ������ ���������� ��� ��������� � ����� ������� ����� ����.
    * fileName = (P1)(P2)(P3)... ... index. ������: PlayerHayaro1 - ������ ������ ����� Player � Hayaro
    * ���������� ����� ����������� � ������ �����
    * ���������� �� �������, �������� ��� ��������� � ��� ������ � lines
    */


    // ��������� ����� �������:
    // speaker;line
    // speaker;line
    // ...
    // ����: � ����� ������� ����� ����������� �������� � ���, ����������� �� ������� index ��� ��������� �������������� ���� ����������


    private DialogManager dm; // ������ �� Dialog Manager, ��������� ������� � �����
    private UIManager uim;    // ��� ���������/���������� UI �������
    private DialogUIScript DialogUI; // ��������� UI �������

    private List<GameObject> participants = new List<GameObject>(); // ������ ����������� � ������� ��������
    private string fileName; // ��� ����� � ��������
    private List<string> lines = new List<string>(); // ������ ���� �������

    // ��������! �������� ������� ��������� ������ ��������� � ������ ��������� � �����

    public Dialog(GameObject[] participants, int index)
    {
        dm = GameObject.Find("GameManager").GetComponent<DialogManager>();
        uim = GameObject.Find("UIManager").GetComponent<UIManager>();
        fileName = "";
        foreach (GameObject p in participants)
        {
            this.participants.Add(p);                    // ��������� ���������� �������
            fileName += p.name;                          // �������� ID ��� ������ � �����
        }
        fileName += index.ToString();                    // � ����� ��������� ����� ������� ����� �����������
        fileName += ".txt";

        // ������ ��������� ���� � ��������.
        string file = File.ReadAllText(Application.dataPath + "/DialogSystem/Dialogs/" + fileName);
        string[] linesFromFile = file.Split("\n");
        foreach (string line in linesFromFile)
        {
            lines.Add(line);
        }

        // ��������� � �� ������� ���������. ������ ���������� � UI:

        // �������� � ��������� ����������� UI
        DialogUI = uim.LoadUI("DialogUI").GetComponent<DialogUIScript>();
        uim.UnloadUI("HUD");

        //��������� ���������� ������ �������
        Refresh();
    }

    public void Refresh() // ��������� ���������� ���� �������
    {
        // �������� ������ � �������
        string name = lines[dm.currentLine].Split(";")[0];
        string text = lines[dm.currentLine].Split(";")[1];
        DialogUI.SetCharacterName(lines[dm.currentLine].Split(";")[0]);
        DialogUI.SetCharacterText(lines[dm.currentLine].Split(";")[1]);
        DialogUI.SetCharacterImage(dm.GetCharacterSpriteByName(name));
    }

    public int GetTotalLines() // ����� ���� � �����
    {
        return lines.Count;
    }

    public void Quit()  // ��� ������ �� �������
    {
        // ���� ����� ���������� ���� �����, ���� ��������� InDialog  = false;
        foreach (GameObject obj in participants)
        {
            if (obj.tag == "Player")
            {
                obj.GetComponent<PlayerInstance>().InDialog = false;
            }
        }
        // ���������� UI �� �����
        uim.LoadUI("HUD");
        uim.UnloadUI("DialogUI");
    }
}

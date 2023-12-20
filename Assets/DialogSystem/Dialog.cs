using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class Dialog //����� ��� ����� ����� �������� ������� �������!
{
    /* ������ ������� ��������� ��� ��������� �������.
    * ��� �������� � ������ ���������� ��� ��������� � ����� ������� ����� ����.
    * fileName = (P1)(P2)(P3)... ... index. ������: PlayerHayaro1 - ������ ������ ����� Player � Hayaro
    * ���������� ����� ����������� � ������ �����
    * ���������� �� �������, �������� ��� ��������� � ��� ������ � lines
    */

    // ��������� ����� �������:
    // speaker; line
    // speaker; line
    // ...

    private GameObject dialogUIObject;  //UI GameObjects
    private GameObject hudUIObject;
    private DIalogUI dialogUI;

    private List<GameObject> participants = new List<GameObject>();
    private string fileName;
    private List<string> lines = new List<string>();

    private int currentLine;

    public Dialog(GameObject[] participants, int index)
    {
        currentLine = 0;
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
        Debug.Log(lines[0]);

        // ��������� � �� ������� ���������. ������ ���������� � UI:
        // �������� � ��������� ����������� UI
        dialogUIObject = GameObject.FindObjectsOfType<GameObject>(true).Where(obj => obj.name == "DialogUI").ToArray()[0];
        hudUIObject = GameObject.FindObjectsOfType<GameObject>(true).Where(obj => obj.name == "HUD").ToArray()[0];
        dialogUIObject.SetActive(true);
        hudUIObject.SetActive(false);

        // �������� ������ � �������
        dialogUI = dialogUIObject.GetComponent<DIalogUI>();
        dialogUI.SetCharacterName(lines[0].Split(";")[0]);
        dialogUI.SetCharacterText(lines[0].Split(";")[1]);
        // ��� ������ ����������� ��������... (�������� �����)
    }

    public void Advance() // ����������� �� ������� � ��������� �����
    {
        currentLine++;
        if (currentLine < lines.Count)  // ���������, �� ��������� �� ������
        {
            // �������� ������ � �������
            dialogUI.SetCharacterName(lines[currentLine].Split(";")[0]);
            dialogUI.SetCharacterText(lines[currentLine].Split(";")[1]);
        }
        else
        {
            Quit();
        }
    }

    private void Quit()  // ����� �� �������
    {
        // ���� ����� ���������� ���� �����, Talking = false;
        foreach (GameObject obj in participants)
        {
            if (obj.tag == "Player")
            {
                obj.GetComponent<PlayerInstance>().InDialog = false;
            }
        }
        dialogUIObject.SetActive(false);
        hudUIObject.SetActive(true);
    }
}

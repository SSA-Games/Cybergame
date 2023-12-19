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
    private List<string> lines;

    private int currentLine;

    public Dialog(GameObject[] participants, int index)
    {
        currentLine = 0;
        fileName = "";
        foreach (GameObject p in participants)
        {
            this.participants.Add(p);                    // ��������� ���������� �������
            fileName += p.name;                       // �������� ID ��� ������ � �����
        }
        fileName += index.ToString();                    // � ����� ��������� ����� ������� ����� �����������
        fileName += ".json";

        // ������ ��������� ���� � ��������.

        string json = File.ReadAllText(Application.dataPath + "/DialogSystem/Dialogs/" + fileName);
        lines = JsonUtility.FromJson<List<string>>(json);

        // ������ ���������������. ������ ���������� � UI:
        // �������� � ��������� ����� UI
        dialogUIObject = GameObject.FindObjectsOfType<GameObject>().Where(obj => obj.name == "DialogUI").ToArray()[0];
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
        dialogUIObject.SetActive(true);
        hudUIObject.SetActive(false);
    }
}

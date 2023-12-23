using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    // ������ ���� �������� ���������� ��� ��������. ��������! �������� ������� ������ ��������� � ������ ��������� � �����!
    public List<Sprite> characterSprites = new List<Sprite>();

    private Dialog currentDialog;
    public int currentLine { get; private set; } //������� ������ �������. ��� ���������� ������������ ������ �������������
    public void ContinueDialog()
    {
        currentLine++;
        if (currentLine < currentDialog.GetTotalLines())
        {
            currentDialog.Refresh();
        }
        else
        {
            QuitDialog();
        }
    }

    public void QuitDialog() // ����� �� ��������� �������? ������� ���� ������������� ��������
    {
        currentDialog.Quit(); // ��� ��� ������ ��� ������
        currentDialog = null;
        Time.timeScale = 1f;
        currentLine = 0;
    }

    public void InitiateDialog(GameObject[] participants, int index) // ��������� � ����� ������� ����� ����������� (����� ���� �� ���� ������ ����� �����������)
    {
        Time.timeScale = 0;
        currentLine = 0;
        currentDialog = new Dialog(participants, index);
    }

    public Sprite GetCharacterSpriteByName(string name)
    {
        foreach(Sprite sprite in characterSprites)
        {
            if (sprite.name == name)
            {
                return sprite;
            }
        }
        Debug.Log("Couldn't find sprite with name " + name);
        return null;
    }
}

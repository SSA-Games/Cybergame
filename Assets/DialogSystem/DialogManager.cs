using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    // Список всех спрайтов персонажей для диалогов. ВНИМАНИЕ! НАЗВАНИЕ СПРАЙТА ДОЛЖНО СОВПАДАТЬ С ИМЕНЕМ ПЕРСОНАЖА В ФАЙЛЕ!
    public List<Sprite> characterSprites = new List<Sprite>();

    private Dialog currentDialog;
    public int currentLine { get; private set; } //Текущая строка диалога. При достижении максимальной диалог заканчивается
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

    public void QuitDialog() // Можно ли прерывать диалоги? Создать флаг прерываемости диалогов
    {
        currentDialog.Quit(); // Тут вся логика при выходе
        currentDialog = null;
        Time.timeScale = 1f;
        currentLine = 0;
    }

    public void InitiateDialog(GameObject[] participants, int index) // Участники и номер диалога между участниками (может быть не один диалог между участниками)
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

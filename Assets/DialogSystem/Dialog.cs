using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class Dialog //Также еще нужно будет добавить систему выборов!
{
    /* Объект диалога создается при инициации диалога.
    * При создании в диалог передаются его участники и номер диалога между ними.
    * fileName = (P1)(P2)(P3)... ... index. Пример: PlayerHayaro1 - первый диалог между Player и Hayaro
    * Содержимое файла загружается в массив строк
    * Происходим по строкам, загружая имя участника и его строку в lines
    */

    // Структура файла диалога:
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
            this.participants.Add(p);                    // Добавляем участников диалога
            fileName += p.name;                       // Получаем ID для поиска в файле
        }
        fileName += index.ToString();                    // В конце добавляем номер диалога между участниками
        fileName += ".json";

        // Теперь прочитаем файл с диалогом.

        string json = File.ReadAllText(Application.dataPath + "/DialogSystem/Dialogs/" + fileName);
        lines = JsonUtility.FromJson<List<string>>(json);

        // Диалог инициализирован. Теперь обращаемся к UI:
        // Включаем и выключаем новый UI
        dialogUIObject = GameObject.FindObjectsOfType<GameObject>().Where(obj => obj.name == "DialogUI").ToArray()[0];
        hudUIObject = GameObject.FindObjectsOfType<GameObject>(true).Where(obj => obj.name == "HUD").ToArray()[0];
        dialogUIObject.SetActive(true);
        hudUIObject.SetActive(false);

        // Заменяем тексты и спрайты
        dialogUI = dialogUIObject.GetComponent<DIalogUI>();
        dialogUI.SetCharacterName(lines[0].Split(";")[0]);
        dialogUI.SetCharacterText(lines[0].Split(";")[1]);
        // Еще должна загружаться картинка... (вставить позже)
    }

    public void Advance() // Продвижение по диалогу к следующей фразе
    {
        currentLine++;
        if (currentLine < lines.Count)  // Проверяем, не закончили мы диалог
        {
            // Заменяем тексты и спрайты
            dialogUI.SetCharacterName(lines[currentLine].Split(";")[0]);
            dialogUI.SetCharacterText(lines[currentLine].Split(";")[1]);
        }
        else
        {
            Quit();
        }
    }

    private void Quit()  // Выход из диалога
    {
        dialogUIObject.SetActive(true);
        hudUIObject.SetActive(false);
    }
}

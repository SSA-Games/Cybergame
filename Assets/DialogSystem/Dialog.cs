using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class Dialog 
{
    /* Объект диалога создается при инициации диалога.
    * При создании в диалог передаются его участники и номер диалога между ними.
    * fileName = (P1)(P2)(P3)... ... index. Пример: PlayerHayaro1 - первый диалог между Player и Hayaro
    * Содержимое файла загружается в массив строк
    * Происходим по строкам, загружая имя участника и его строку в lines
    */


    // Структура файла диалога:
    // speaker;line
    // speaker;line
    // ...
    // ИДЕЯ: в файле диалога будут содержаться указания о том, увеличивать ли счетчик index при следующем взаимодействии этих участников


    private DialogManager dm; // Ссылка на Dialog Manager, интерфейс диалога с игрой
    private UIManager uim;    // Для включения/выключения UI диалога
    private DialogUIScript DialogUI; // Хранилище UI диалога

    private List<GameObject> participants = new List<GameObject>(); // Список участвующих в диалоге объектов
    private string fileName; // Имя файла с диалогом
    private List<string> lines = new List<string>(); // Список фраз диалога

    // ВНИМАНИЕ! НАЗВАНИЕ СПРАЙТА ПЕРСОНАЖА ДОЛЖНО СОВПАДАТЬ С ИМЕНЕМ ПЕРСОНАЖА В ФАЙЛЕ

    public Dialog(GameObject[] participants, int index)
    {
        dm = GameObject.Find("GameManager").GetComponent<DialogManager>();
        uim = GameObject.Find("UIManager").GetComponent<UIManager>();
        fileName = "";
        foreach (GameObject p in participants)
        {
            this.participants.Add(p);                    // Добавляем участников диалога
            fileName += p.name;                          // Получаем ID для поиска в файле
        }
        fileName += index.ToString();                    // В конце добавляем номер диалога между участниками
        fileName += ".txt";

        // Теперь прочитаем файл с диалогом.
        string file = File.ReadAllText(Application.dataPath + "/DialogSystem/Dialogs/" + fileName);
        string[] linesFromFile = file.Split("\n");
        foreach (string line in linesFromFile)
        {
            lines.Add(line);
        }

        // Участники и их реплики загружены. Теперь обращаемся к UI:

        // Включаем и выключаем необходимый UI
        DialogUI = uim.LoadUI("DialogUI").GetComponent<DialogUIScript>();
        uim.UnloadUI("HUD");

        //Обновляем содержимое окошка диалога
        Refresh();
    }

    public void Refresh() // Обновляем содержание окна диалога
    {
        // Заменяем тексты и спрайты
        string name = lines[dm.currentLine].Split(";")[0];
        string text = lines[dm.currentLine].Split(";")[1];
        DialogUI.SetCharacterName(lines[dm.currentLine].Split(";")[0]);
        DialogUI.SetCharacterText(lines[dm.currentLine].Split(";")[1]);
        DialogUI.SetCharacterImage(dm.GetCharacterSpriteByName(name));
    }

    public int GetTotalLines() // Всего фраз в файле
    {
        return lines.Count;
    }

    public void Quit()  // При выходе из диалога
    {
        // Если среди участников есть игрок, флаг состояния InDialog  = false;
        foreach (GameObject obj in participants)
        {
            if (obj.tag == "Player")
            {
                obj.GetComponent<PlayerInstance>().InDialog = false;
            }
        }
        // Возвращаем UI на место
        uim.LoadUI("HUD");
        uim.UnloadUI("DialogUI");
    }
}

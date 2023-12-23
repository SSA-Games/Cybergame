using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

public class UIManager : MonoBehaviour // Менеджер для управления текущим окном UI
{
    /*
     * У нас есть следующие UI, требующие контроля: HUD, DialogUI, PauseUI, OptionsUI...
     * В каждый момент времени на экране находится лишь один UI
     * Каждый UI должен иметь префаб
     * По желанию пользователя активируем необходимый UI
     */

    // Необходимые префабы UI
    public List<GameObject> UIPrefabs = new List<GameObject>();
    // Список названий загруженных объектов
    private List<string> UILoaded = new List<string>();

    public void Awake()
    {
        // При первом запуске уровня загружается HUD
        LoadUI("HUD");
    }

    public GameObject LoadUI(string name) // Включение UI. Возвращаем объект c UI
    {
        foreach (GameObject prefab in UIPrefabs)
        {
            if (prefab.name == name && !UILoaded.Contains(name + "(Clone)")) // Находим объект и проверяем, что он еще не загружен
            {
                GameObject obj = Instantiate(prefab);
                UILoaded.Add(obj.name);
                return obj;
            }
        }
        Debug.Log("Couldn't find the UI prefab with name \"" + name + "\" in the list");
        return null;
    }

    public void UnloadUI(string name) // Выключение UI
    {
        GameObject obj = GameObject.Find(name + "(Clone)");
        if (obj != null)
        {
            Destroy(obj);
            UILoaded.Remove(name + "(Clone)");
        }
        else
        {
            Debug.Log("Couldn't unload UI. Object \"" + name + "(Clone)\" not found");
        }
    }
}

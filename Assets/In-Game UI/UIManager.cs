using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

public class UIManager : MonoBehaviour // �������� ��� ���������� ������� ����� UI
{
    /*
     * � ��� ���� ��������� UI, ��������� ��������: HUD, DialogUI, PauseUI, OptionsUI...
     * � ������ ������ ������� �� ������ ��������� ���� ���� UI
     * ������ UI ������ ����� ������
     * �� ������� ������������ ���������� ����������� UI
     */

    // ����������� ������� UI
    public List<GameObject> UIPrefabs = new List<GameObject>();
    // ������ �������� ����������� ��������
    private List<string> UILoaded = new List<string>();

    public void Awake()
    {
        // ��� ������ ������� ������ ����������� HUD
        LoadUI("HUD");
    }

    public GameObject LoadUI(string name) // ��������� UI. ���������� ������ c UI
    {
        foreach (GameObject prefab in UIPrefabs)
        {
            if (prefab.name == name && !UILoaded.Contains(name + "(Clone)")) // ������� ������ � ���������, ��� �� ��� �� ��������
            {
                GameObject obj = Instantiate(prefab);
                UILoaded.Add(obj.name);
                return obj;
            }
        }
        Debug.Log("Couldn't find the UI prefab with name \"" + name + "\" in the list");
        return null;
    }

    public void UnloadUI(string name) // ���������� UI
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

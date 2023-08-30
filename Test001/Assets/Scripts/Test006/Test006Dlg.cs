using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test006Dlg : MonoBehaviour
{
    [SerializeField] Text result = null;
    [SerializeField] Button btn_Ok = null;
    [SerializeField] Button btn_Clear = null;

    List<int> list = new List<int>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        btn_Ok.onClick.AddListener(OnClicked_Ok);
        btn_Clear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Ok()
    {
        list.Clear();

        string str = string.Empty;

        list.Add(10);
        list.Add(20);
        list.Add(30);

        str += TestList(list);

        list.Add(40);
        list.Add(50);
        str += "[ List : foreach 문 ]\n";
        str += TestForeach(list);

        list.Remove(10);
        list.Remove(40);
        str += "[ 리스트 삭제 - foreach ]\n";
        str += TestForeach(list);

        result.text = str;
    }

    void OnClicked_Clear()
    {
        result.text = "초기화";
    }

    string TestList(List<int> l)
    {
        string str = $"[ List : for문 ]\n";
        for (int i = 0; i < l.Count; i++)
        {
            str += $"[{i}]: {list[i]}, ";
        }
        str += "\n--------------------------------------------\n";

        return str;
    }

    string TestForeach(List<int> l)
    {
        string str = string.Empty;
        foreach (int i in l)
        {
            str += $"{i}, ";
        }

        str += "\n--------------------------------------------\n";

        return str;
    }
}

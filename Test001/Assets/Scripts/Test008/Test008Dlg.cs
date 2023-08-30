using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test008Dlg : MonoBehaviour
{
    [SerializeField] Text result = null;
    [SerializeField] Button btn_Ok = null;
    [SerializeField] Button btn_Clear = null;

    Dictionary<int, string> dic = new Dictionary<int, string>();

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
        result.text = string.Empty;
        dic.Clear();

        dic.Add(1, "���");
        dic.Add(2, "��");
        dic.Add(3, "����");
        result.text += PrintDic(dic);

        dic[1] = "���ִ� ���";
        dic[2] = "���ִ� ��";
        result.text += PrintDic(dic);

        dic.Remove(1);
        result.text += PrintDic(dic);
    }

    void OnClicked_Clear()
    {
        dic.Clear();
        result.text = "�ʱ�ȭ";
    }

    string PrintDic(Dictionary<int, string> d)
    {
        string str = string.Empty;

        foreach (KeyValuePair<int, string> item in d)
        {
            str += $"{item.Key}, {item.Value} / ";
        }

        str += "\n-----------------------------------------\n";

        return str;
    }
}

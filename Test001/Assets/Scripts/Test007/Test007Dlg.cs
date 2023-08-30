using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test007Dlg : MonoBehaviour
{
    [SerializeField] InputField inputNum = null;
    [SerializeField] Text result = null;
    [SerializeField] Text txt_nums = null;
    [SerializeField] Button btn_Ok = null;
    [SerializeField] Button btn_Clear = null;
    [SerializeField] Button btn_Add = null;

    List<int> list = new List<int>();

    private void Start()
    {
        Init();
    }

    void Init()
    {
        btn_Ok.onClick.AddListener(OnClicked_Ok);
        btn_Clear.onClick.AddListener(OnClicked_Clear);
        btn_Add.onClick.AddListener(OnClicked_Add);
    }

    void OnClicked_Ok()
    {
        if(list.Count <= 0)
        {
            Debug.Log("����Ʈ�� ������ϴ�.");
            return;
        }

        list.Sort((a, b) => a > b ? 1 : -1);
        string str = PrintList(list);

        result.text = str;
    }

    void OnClicked_Clear()
    {
        inputNum.text = string.Empty;
        txt_nums.text = "�ʱ�ȭ";
        result.text = "�ʱ�ȭ";
        list.Clear();
    }

    void OnClicked_Add()
    {
        if (list.Count >= 5)
        {
            Debug.Log("5���� �Ѿ����ϴ�.");
            return;
        }

        if (inputNum.text == "")
        {
            Debug.Log("�Է°��� �����ϴ�.");
            return;
        }

        int num = int.Parse(inputNum.text);

        if(num < 0 || num > 100)
        {
            Debug.Log("���ڰ� ������ ������ϴ�.");
            return;
        }

        list.Add(num);
        string str = PrintList(list);

        txt_nums.text = str;
    }

    string PrintList(List<int> l)
    {
        string str = string.Empty;

        for (int i = 0; i < l.Count; i++)
        {
            str += $"{l[i]}, ";
        }

        return str;
    }
} 

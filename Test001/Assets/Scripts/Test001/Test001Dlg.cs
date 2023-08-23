using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test001Dlg : MonoBehaviour
{
    [SerializeField] Text txt = null;
    [SerializeField] Button btn_Ok = null;
    [SerializeField] Button btn_Clear = null;

    int num1 = 100;
    int num2 = 200;
    string str;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        btn_Ok.onClick.AddListener(() => OnClicked_Ok());
        btn_Clear.onClick.AddListener(() => OnClicked_Clear());
    }

    void OnClicked_Ok()
    {
        str = string.Empty;

        int sum = Sum(10, 20);

        str += $"sum = {sum}\n----------------------------\n\n";

        str += $"a = {num1} b = {num2}\n";
        Swap1(num1, num2);
        str += $"a = {num1} b = {num2}\n";
        Swap2(ref num1, ref num2);
        str += $"a = {num1} b = {num2}\n----------------------------";

        txt.text = str;
    }

    void OnClicked_Clear()
    {
        txt.text = "초기화 되었습니다.";
    }


    int Sum(int a, int b)
    {
        return a + b;
    }

    void Swap1(int a, int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    void Swap2(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}

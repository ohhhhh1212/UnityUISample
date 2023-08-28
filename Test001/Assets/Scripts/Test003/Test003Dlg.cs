using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test003Dlg : MonoBehaviour
{
    [SerializeField] InputField in_num1 = null;
    [SerializeField] InputField in_num2 = null;
    [SerializeField] InputField in_num3 = null;
    [SerializeField] Button btn_OK = null;
    [SerializeField] Button btn_Clear = null;
    [SerializeField] Text result = null;


    void Start()
    {
        Init();
    }

    void Init()
    {
        btn_OK.onClick.AddListener(OnClicked_Ok);
        btn_Clear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Ok()
    {
        result.text = string.Empty;

        int num1 = int.Parse(in_num1.text);
        int num2 = int.Parse(in_num2.text);
        int num3 = int.Parse(in_num3.text);

        if(num1 < num2) // 2 > 1
        {
            if(num2 < num3) // 3 > 2 > 1
            {
                Swap(ref num1, ref num3);
            }
            else if(num1 > num3) // 2 > 1 > 3 
            {
                Swap(ref num1, ref num2);
            }
            else if(num1 < num3) // 2 > 3 > 1
            {
                Swap(ref num1, ref num2);
                Swap(ref num2, ref num3);
            }
        }
        else // 1 > 2
        {
            if(num1 < num3) // 3 > 1 > 2
            {
                Swap(ref num1, ref num3);
                Swap(ref num2, ref num3);
            }
            else if(num2 > num3) // 1 > 2 > 3
            {
                // 입력 받은 순서 그대로
            }
            else if(num2 < num3) // 1 > 3 > 2
            {
                Swap(ref num2, ref num3);
            }
        }

        result.text += $"가장 큰 수 : {num1}\n{num1}, {num2}, {num3}";
    }

    void OnClicked_Clear()
    {
        result.text = "초기화";
        in_num1.text = "";
        in_num2.text = "";
        in_num3.text = "";
    }

    void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test004Dlg : MonoBehaviour
{
    [SerializeField] InputField num = null;
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

        int input = int.Parse(num.text);

        if (input > 10 || input < 0)
        {
            result.text = "숫자가 범위를 벗어 났습니다";
            return;
        }

        for (int i = 1; i <= input; i++)
        {
            result.text += $"{i}*";
        }
        result.text += " = ";

        int fac = Factorial(input);

        result.text += $"{fac}";
    }

    void OnClicked_Clear()
    {
        result.text = "초기화";
        num.text = string.Empty;
    }

    int Factorial(int num)
    {
        int f = 1;
        for (int i = 1; i <= num; i++)
        {
            f *= i;
        }

        return f;
    }
}

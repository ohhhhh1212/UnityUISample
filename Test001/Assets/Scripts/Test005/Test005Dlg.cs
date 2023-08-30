using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test005Dlg : MonoBehaviour
{
    [SerializeField] Text result = null;
    [SerializeField] Button btn_Ok = null;
    [SerializeField] Button btn_Clear = null;

    void Start()
    {
        Init();
    }

    void Init()
    {
        btn_Ok.onClick.AddListener(OnClicked_Ok);
        btn_Clear.onClick.AddListener(OnClicked_Clear);
    }

    int[] arr = { 100, 200, 300 };
    int[,] arr1 = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
    int[,] arr2 = new int[3, 2];

    void OnClicked_Ok()
    {
        //string str = string.Empty;
        //result.text = string.Empty;

        //str += Test_For();
        //str += "\n";
        //str += Test_While();
        //str += "\n";
        //str += Test_DoWhile();

        //result.text = str;

        string str = string.Empty;

        str += Test_Arr(arr1);

        arr2[0, 0] = 1;
        arr2[0, 1] = 2;
        arr2[1, 0] = 3;
        arr2[1, 1] = 4;
        arr2[2, 0] = 5;
        arr2[2, 1] = 6;

        str += Test_Arr(arr2);

        result.text = str;
    }

    void OnClicked_Clear()
    {
        result.text = "초기화";
    }

    string Test_For()
    {
        string str = "[ for문 테스트 ]\n";

        for (int i = 0; i < arr.Length; i++)
        {
            str += $"Arr[{i}] = {arr[i]}, ";
        }

        str += "\n-----------------------------------------------------------\n";

        return str;
    }

    string Test_While()
    {
        string str = "[ While문 테스트 ]\n";
        int i = 0;

        while(i < arr.Length)
        {
            str += $"Arr[{i}] = {arr[i]}, ";
            i += 1;
        }

        str += "\n-----------------------------------------------------------\n";

        return str;
    }

    string Test_DoWhile()
    {
        string str = "[ doWhile문 테스트 ]\n";
        int i = 0;

        do
        {
            str += $"Arr[{i}] = {arr[i]}, ";
            i += 1;
        } while (i < arr.Length);

        str += "\n-----------------------------------------------------------\n";

        return str;
    }

    string Test_Arr(int[,] arr)
    {
        string str = "[ 2차원 배열 ]\n";

        for (int i = 0; i < arr1.GetLength(0); i++)
        {
            for (int j = 0; j < arr1.GetLength(1); j++)
            {
                str += $"arr[{i}], [{j}] = {arr1[i,j]}\n";
            }
        }

        str += "---------------------------------------\n";

        return str;
    }
}

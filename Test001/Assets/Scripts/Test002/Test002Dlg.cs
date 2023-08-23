using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test002Dlg : MonoBehaviour
{
    [SerializeField] InputField score = null;
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

    void OnClicked_Ok()
    {
        int i = int.Parse(score.text);
       //string rank = TestIf(i);

        string rank = TestSwitch(i);

        result.text = $"당신의 등급은 {rank}입니다.";
    }

    void OnClicked_Clear()
    {
        result.text = "초기화 되었습니다.";
        score.text = string.Empty;
    }


    string TestIf(int s)
    {
        string rank = "";
        if (s >= 90) rank = "A";
        else if (s >= 80) rank = "B";
        else if (s >= 70) rank = "C";
        else if (s >= 60) rank = "D";
        else  rank = "F";

        return rank;
    }

    string TestSwitch(int s)
    {
        string rank = "";
        switch (s)
        {
            case >= 90:
                rank = "A";
                break;
            case >= 80:
                rank = "B";
                break;
            case >= 70:
                rank = "C";
                break;
            case >= 60:
                rank = "D";
                break;
            case < 60:
                rank = "F";
                break;
        }

        return rank;
    }
}

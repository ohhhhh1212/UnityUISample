using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score
{
    public string name = "";
    public int korean = 0;
    public int english = 0;
    public int math = 0;

    public int GetTotal()
    {
        return korean + english + math;
    }

    public float GetAvg()
    {
        return (float)GetTotal() / 3;
    }

    public Score(string n, int k, int e, int m)
    {
        name = n;
        korean = k;
        english = e;
        math = m;
    }
}

public class Test012Dlg : MonoBehaviour
{
    [SerializeField] InputField input_name = null;
    [SerializeField] InputField input_kor = null;
    [SerializeField] InputField input_eng = null;
    [SerializeField] InputField input_math = null;
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
        if(input_name.text == "" || input_kor.text == "" || input_eng.text == "" || input_math.text == "")
        {
            result.text = "���� �Է� ���� �ʾҽ��ϴ�.";
            return;
        }

        string name = input_name.text;
        int kor = int.Parse(input_kor.text);
        int eng = int.Parse(input_eng.text);
        int math = int.Parse(input_math.text);

        if(kor < 0 || kor > 100 || eng < 0 || eng > 100 || math < 0 || math > 100)
        {
            result.text = "���� ������ ������ϴ�.";
            return;
        }

        Score score = new Score(name, kor, eng, math);

        string str = string.Empty;

        str += string.Format("�̸� : {0}\n", score.name);
        str += string.Format("���� : {0}, ���� : {1}, ���� : {2}\n", score.korean, score.english, score.math);
        str += string.Format("�հ� : {0}, ��� : {1:0.00}", score.GetTotal(), score.GetAvg());

        result.text = str;
    }

    void OnClicked_Clear()
    {
        result.text = "�ʱ�ȭ";
    }

}

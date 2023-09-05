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
            result.text = "값이 입력 되지 않았습니다.";
            return;
        }

        string name = input_name.text;
        int kor = int.Parse(input_kor.text);
        int eng = int.Parse(input_eng.text);
        int math = int.Parse(input_math.text);

        if(kor < 0 || kor > 100 || eng < 0 || eng > 100 || math < 0 || math > 100)
        {
            result.text = "값이 범위를 벗어났습니다.";
            return;
        }

        Score score = new Score(name, kor, eng, math);

        string str = string.Empty;

        str += string.Format("이름 : {0}\n", score.name);
        str += string.Format("국어 : {0}, 영어 : {1}, 수학 : {2}\n", score.korean, score.english, score.math);
        str += string.Format("합계 : {0}, 평균 : {1:0.00}", score.GetTotal(), score.GetAvg());

        result.text = str;
    }

    void OnClicked_Clear()
    {
        result.text = "초기화";
    }

}

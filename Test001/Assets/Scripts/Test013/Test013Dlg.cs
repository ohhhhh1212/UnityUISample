using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test013Dlg : MonoBehaviour
{
    public class Score
    {
        public string name = "";
        public int korean = 0;
        public int english = 0;
        public int math = 0;

        public int Total
        {
            get
            {
                return korean + english + math;
            }
        }
        public float Average
        {
            get
            {
                return (float)Total / 3;
            }
        }

        public Score(string n, int k, int e, int m)
        {
            name = n;
            korean = k;
            english = e;
            math = m;
        }
    }

    [SerializeField] InputField input_name = null;
    [SerializeField] InputField input_kor = null;
    [SerializeField] InputField input_eng = null;
    [SerializeField] InputField input_math = null;
    [SerializeField] Button btn_Add = null;
    [SerializeField] Button btn_Ok = null;
    [SerializeField] Button btn_Clear = null;
    [SerializeField] Text txt_result = null;
    [SerializeField] Text txt_added = null;

    List<Score> scores = new List<Score>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        btn_Add.onClick.AddListener(OnClicked_Add);
        btn_Ok.onClick.AddListener(OnClicked_Ok);
        btn_Clear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Add()
    {
        if (input_name.text == "" || input_kor.text == "" || input_eng.text == "" || input_math.text == "")
        {
            txt_result.text = "���� �Է� ���� �ʾҽ��ϴ�.";
            return;
        }

        string name = input_name.text;
        int kor = int.Parse(input_kor.text);
        int eng = int.Parse(input_eng.text);
        int math = int.Parse(input_math.text);

        if (kor < 0 || kor > 100 || eng < 0 || eng > 100 || math < 0 || math > 100)
        {
            txt_result.text = "���� ������ ������ϴ�.";
            return;
        }

        Score score = new Score(name, kor, eng, math);

        scores.Add(score);

        string str = "";

        for (int i = 0; i < scores.Count; i++)
        {
            Score kscore = scores[i];
            str += $"{kscore.name} : {kscore.korean}, {kscore.english}, {kscore.math}\n";
        }

        txt_added.text = str;

        input_name.text = string.Empty;
        input_kor.text = string.Empty;
        input_eng.text = string.Empty;
        input_math.text = string.Empty;
    }

    void OnClicked_Ok()
    {
        string str = "[��������]\n";
        str += "============================================\n";

        scores.Sort((a, b) => a.Total < b.Total ? 1 : -1);

        for (int i = 0; i < scores.Count; i++)
        {
            Score score = scores[i];

            str += $"{score.name} : {score.korean}, {score.english}, {score.math} : ";
            str += string.Format("�հ� = {0} ��� = {1:0.00}\n", score.Total, score.Average);
        }

        txt_result.text = str;
    }

    void OnClicked_Clear()
    {
        scores.Clear();
        txt_result.text = "�ʱ�ȭ";
        txt_added.text = "�ʱ�ȭ";
        input_name.text = string.Empty;
        input_kor.text = string.Empty;
        input_eng.text = string.Empty;
        input_math.text = string.Empty;
    }
}

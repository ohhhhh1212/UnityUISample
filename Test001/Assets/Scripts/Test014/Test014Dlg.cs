using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Test014Dlg : MonoBehaviour
{
    public class Score
    {
        public string name = "";
        public int kor = 0;
        public int eng = 0;
        public int math = 0;

        public int Total { get { return kor + eng + math; } }
        public float Average {  get { return (float)Total / 3; } }

        public Score(string n, int k, int e, int m)
        {
            name = n;
            kor = k;
            eng = e;
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
    [SerializeField] Button btn_Save = null;
    [SerializeField] Button btn_Load = null;
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
        btn_Save.onClick.AddListener(OnClicked_Save);
        btn_Load.onClick.AddListener(OnClicked_Load);
    }

    void OnClicked_Add()
    {
        if(input_name.text == "" || input_kor.text == "" || input_eng.text == "" || input_math.text == "")
        {
            txt_result.text = "값을 입력해주세요.";
            return;
        }

        string name = input_name.text;
        int kor = int.Parse(input_kor.text);
        int eng = int.Parse(input_eng.text);
        int math = int.Parse(input_math.text);

        if(kor < 0 || kor > 100 || eng < 0 || eng > 100 || math < 0 || math > 100)
        {
            txt_result.text = "값이 범위를 벗어났습니다.";
            return;
        }

        Score score = new Score(name, kor, eng, math);

        scores.Add(score);

        string str = "";

        for (int i = 0; i < scores.Count; i++)
        {
            Score kscore = scores[i];
            str += $"{kscore.name} : {kscore.kor}, {kscore.eng}, {kscore.math}\n";
        }

        txt_added.text = str;

        input_name.text = string.Empty;
        input_kor.text = string.Empty;
        input_eng.text = string.Empty;
        input_math.text = string.Empty;
    }

    void OnClicked_Ok()
    {
        scores.Sort((a, b) => a.Total < b.Total ? 1 : -1);

        PrintResult();
    }

    void OnClicked_Clear()
    {
        scores.Clear();
        txt_result.text = "초기화";
        txt_result.text = "";
        input_name.text = string.Empty;
        input_kor.text = string.Empty;
        input_eng.text = string.Empty;
        input_math.text = string.Empty;
    }

    float GetAvg(int i)
    {
        return (float)i / scores.Count;
    }

    void PrintResult()
    {
        string str = "[성적관리]\n=========================================\n";

        int totKor = 0;
        int totEng = 0;
        int totMath = 0;

        for (int i = 0; i < scores.Count; i++)
        {
            Score score = scores[i];
            str += string.Format("{0}등 / {1} : {2}, {3}, {4} : ", i + 1, score.name, score.kor, score.eng, score.math);
            str += string.Format("합계 = {0} 평균 = {1:0.00}\n", score.Total, score.Average);
        }

        for (int i = 0; i < scores.Count; i++)
        {
            Score score = scores[i];
            totKor += score.kor;
            totEng += score.eng;
            totMath += score.math;
        }

        str += "=========================================\n과목별 합계 -- ";
        str += string.Format("국어 : ({0}, {1:0.0}), ", totKor, GetAvg(totKor));
        str += string.Format("영어 : ({0}, {1:0.0}), ", totEng, GetAvg(totEng));
        str += string.Format("수학 : ({0}, {1:0.0})", totMath, GetAvg(totMath));

        txt_result.text = str;
    }

    void OnClicked_Save()
    {
        SaveFile();
    }

    void OnClicked_Load()
    {
        LoadFile();
    }

    void SaveFile()
    {
        StreamWriter sw = new StreamWriter("scores.data");

        sw.WriteLine(scores.Count);

        for (int i = 0; i < scores.Count; i++)
        {
            Score score = scores[i];
            sw.WriteLine(score.name);
            sw.WriteLine(score.kor);
            sw.WriteLine(score.eng);
            sw.WriteLine(score.math);
        }

        sw.Close();
    }

    void LoadFile()
    {
        scores.Clear();

        StreamReader sr = new StreamReader("scores.data");

        int count = int.Parse(sr.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());

            Score score = new Score(name, kor, eng, math);
            scores.Add(score);
        }

        sr.Close();

        PrintResult();
    }
}

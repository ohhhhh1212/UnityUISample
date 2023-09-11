using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Test016Dlg : MonoBehaviour
{
    public class Score
    {
        public string name = "";
        public int kor = 0;
        public int eng = 0;
        public int math = 0;

        public int Total { get { return kor + eng + math; } }
        public float Average { get { return (float)Total / 3; } }

        public Score(string n, int k, int e, int m)
        {
            name = n;
            kor = k;
            eng = e;
            math = m;
        }
    }

    [SerializeField] InputField input_Name = null;
    [SerializeField] InputField input_Kor = null;
    [SerializeField] InputField input_Eng = null;
    [SerializeField] InputField input_Math = null;
    [SerializeField] Button btn_Add = null;
    [SerializeField] Button btn_Ok = null;
    [SerializeField] Button btn_Clear = null;
    [SerializeField] Button btn_Save = null;
    [SerializeField] Button btn_Load = null;
    [SerializeField] Text txt_Result = null;
    [SerializeField] Text txt_Added = null;

    List<Score> scores = new List<Score>();

    private void Start()
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
        if (CheckNull())
            return;

        string name = input_Name.text;
        int kor = int.Parse(input_Kor.text);
        int eng = int.Parse(input_Eng.text);
        int math = int.Parse(input_Math.text);

        if(kor < 0 || kor > 100 || eng < 0 || eng > 100 || math < 0 || math > 100)
        {
            txt_Result.text = "값이 범위를 벗어 났습니다.";
            return;
        }

        Score score = new Score(name, kor, eng, math);

        scores.Add(score);

        ClearInput();
        PrintAdded();
    }

    void OnClicked_Ok()
    {
        if(scores.Count == 0)
        {
            txt_Result.text = "입력된 값이 없습니다.";
            return;
        }

        scores.Sort((a, b) => a.Total < b.Total ? 1 : -1);

        PrintResult();
    }

    void OnClicked_Save()
    {
        SaveFile();
    }

    void OnClicked_Load()
    {
        LoadFile();
    }

    void OnClicked_Clear()
    {
        txt_Result.text = "초기화";
        txt_Added.text = "초기화";
        ClearInput();
        scores.Clear();
    }

    void PrintAdded()
    {
        string str = "";

        for (int i = 0; i < scores.Count; i++)
        {
            Score score = scores[i];
            str += $"{score.name} : {score.kor}, {score.eng}, {score.math}\n";
        }

        txt_Added.text = str;
    }

    void PrintResult()
    {
        string str = "[성적관리]\n===========================================\n";

        int totKor = 0;
        int totEng = 0;
        int totMath = 0;

        for (int i = 0; i < scores.Count; i++)
        {
            Score score = scores[i];
            str += $"{i + 1}등 : {score.name} {score.kor} {score.eng} {score.math} ";
            str += string.Format(": 합계 = {0} 평균 = {1:0.0}\n", score.Total, score.Average);

            totKor += score.kor;
            totEng += score.eng;
            totMath += score.math;
        }

        str += "===========================================\n";
        str += "과목별 합계 : ";
        str += string.Format("국어 : ({0}, {1:0.0}), ", totKor, GetAvg(totKor));
        str += string.Format("영어 : ({0}, {1:0.0}), ", totEng, GetAvg(totEng));
        str += string.Format("수학 : ({0}, {1:0.0})", totMath, GetAvg(totMath));

        txt_Result.text = str;
    }

    float GetAvg(int tot)
    {
        return (float)tot / scores.Count;
    }

    void SaveFile()
    {
        StreamWriter sw = new StreamWriter("Test016.data");

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

        Debug.Log("저장 되었습니다.");
    }

    void LoadFile()
    {
        scores.Clear();

        StreamReader sr = new StreamReader("Test016.data");

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

        PrintAdded();

        Debug.Log("불러와 졌습니다.");
    }

    bool CheckNull()
    {
        if (input_Name.text == "" || input_Kor.text == "" || input_Eng.text == "" || input_Math.text == "")
        {
            txt_Result.text = "값을 입력해주세요.";
            return true;
        }

        return false;
    }

    void ClearInput()
    {
        input_Name.text = string.Empty;
        input_Kor.text = string.Empty;
        input_Eng.text = string.Empty;
        input_Math.text = string.Empty;
    }

}

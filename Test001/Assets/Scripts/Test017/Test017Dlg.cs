using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Test017Dlg : MonoBehaviour
{
    public class Student
    {
        public string m_name = "";
        public int m_korean = 0;
        public int m_english = 0;
        public int m_math = 0;

        public string KorRank { get { return Rank(m_korean); } }
        public string EngRank { get { return Rank(m_english); } }
        public string MatRank { get { return Rank(m_math); } }
        public string TotalRank { get { return Rank(Average); } }
        public int Total
        {
            get
            {
                return m_korean + m_english + m_math;
            }
        }
        public float Average
        {
            get
            {
                return (float)Total / 3;
            }
        }

        string Rank(int i)
        {
            string rank = "";

            switch (i)
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
        string Rank(float f)
        {
            string rank = "X";

            switch (f)
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

        public Student(string name, int k, int e, int m)
        {
            m_name = name;
            m_korean = k;
            m_english = e;
            m_math = m;
        }
    }

    [SerializeField] InputField m_inputname = null;
    [SerializeField] InputField m_inputKor = null;
    [SerializeField] InputField m_inputEng = null;
    [SerializeField] InputField m_inputmath = null;
    [Space]
    [SerializeField] Text m_txtAdded = null;
    [SerializeField] Text m_txtResult = null;
    [Space]
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;

    List<Student> m_students = new List<Student>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnLoad.onClick.AddListener(OnClicked_Load);
    }

    void OnClicked_Add()
    {
        CheckError();

        string m_name = m_inputname.text;
        int kor = int.Parse(m_inputKor.text);
        int eng = int.Parse(m_inputEng.text);
        int m_math = int.Parse(m_inputmath.text);

        Student stu = new Student(m_name, kor, eng, m_math);
        m_students.Add(stu);

        ClearInput();
        PrintAdded();
    }

    void PrintAdded()
    {
        string str = "";

        for (int i = 0; i < m_students.Count; i++)
        {
            Student stu = m_students[i];
            str += $"{stu.m_name} : {stu.m_korean}, {stu.m_english}, {stu.m_math}\n";
        }

        m_txtAdded.text = str;
    }

    void OnClicked_Ok()
    {
        m_students.Sort((a, b) => a.Total < b.Total ? 1 : -1);

        PrintResult();
    }

    void PrintResult()
    {
        string str = " No m_name Kor Eng Mat < 종합 >\n";
        str += "===================================\n";

        for (int i = 0; i < m_students.Count; i++)
        {
            Student stu = m_students[i];
            str += $"{i + 1}등 : {stu.m_name} :  {stu.KorRank}   {stu.EngRank}    {stu.MatRank}     <{stu.TotalRank}>\n";
        }

        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        ClearInput();
        m_txtAdded.text = "초기화";
        m_txtResult.text = "초기화";
        m_students.Clear();
    }

    void OnClicked_Save()
    {
        SaveFile();
    }

    void SaveFile()
    {
        StreamWriter sw = new StreamWriter("Test017.txt");

        sw.WriteLine(m_students.Count);

        for (int i = 0; i < m_students.Count; i++)
        {
            Student stu = m_students[i];
            sw.WriteLine(stu.m_name);
            sw.WriteLine(stu.m_korean);
            sw.WriteLine(stu.m_english);
            sw.WriteLine(stu.m_math);
        }

        sw.Close();
    }

    void OnClicked_Load()
    {
        LoadFile();
        PrintAdded();
    }

    void LoadFile()
    {
        m_students.Clear();

        StreamReader sr = new StreamReader("Test017.txt");

        int count = int.Parse(sr.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());

            Student stu = new Student(name, kor, eng, math);
            m_students.Add(stu);
        }

        sr.Close();
    }

    void CheckError()
    {
        if(m_inputname.text == "" || m_inputKor.text == "" || m_inputEng.text == "" || m_inputmath.text == "")
        {
            m_txtResult.text = "값이 입력되지 않았습니다.";
            return;
        }

        int kor = int.Parse(m_inputKor.text);
        int eng = int.Parse(m_inputEng.text);
        int mat = int.Parse(m_inputmath.text);

        if (kor < 0 || kor > 100 || eng < 0 || eng > 100 || mat < 0 || mat > 100)
        {
            m_txtResult.text = "값이 범위를 벗어났습니다.";
            return;
        }
    }

    void ClearInput()
    {
        m_inputname.text = string.Empty;
        m_inputKor.text = string.Empty;
        m_inputEng.text = string.Empty;
        m_inputmath.text = string.Empty;
    }
}

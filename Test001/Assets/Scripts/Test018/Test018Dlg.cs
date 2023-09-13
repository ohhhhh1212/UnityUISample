using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Test018Dlg : MonoBehaviour
{
    public class Info
    {
        public string m_name = "";
        public string m_phone = "";
        public string m_city = "";

        public Info(string name, string ph, string city)
        {
            m_name = name;
            m_phone = ph;
            m_city = city;
        }

        public string GetType(int idx)
        {
            if (idx == 0)
                return m_name;
            else if (idx == 1)
                return m_phone;
            else
                return m_city;
        }
    }

    [SerializeField] InputField m_inputName = null;
    [SerializeField] InputField m_inputPhone = null;
    [SerializeField] InputField m_inputCity = null;
    [SerializeField] InputField m_inputSearch = null;
    [Header("버튼")]
    [Space]
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnSearch = null;
    [SerializeField] Button m_btnOK = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [Space]
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Toggle[] m_toggles = null;    

    List<Info> m_infos = new List<Info>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnSearch.onClick.AddListener(OnClicked_Search);
        m_btnOK.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnLoad.onClick.AddListener(OnClicked_Load);
    }

    void OnClicked_Add()
    {
        if (CheckInput())
            return;

        string name = m_inputName.text;
        string phone = m_inputPhone.text;
        string city = m_inputCity.text;

        Info info = new Info(name, phone, city);
        m_infos.Add(info);

        ClearInput();
    }

    void OnClicked_Search()
    {
        PrintSearch();
    }

    void PrintSearch()
    {
        string str = GetDefaultStr();

        string search = m_inputSearch.text;

        int count = 1;

        int idx = 0;
        for (int i = 0; i < m_toggles.Length; i++)
        {
            if (m_toggles[i].isOn)
                idx = i;
        }

        for (int i = 0; i < m_infos.Count; i++)
        {
            if (m_infos[i].GetType(idx).Contains(search))
            {
                Info info = m_infos[i];
                str += $"{count++}   {info.m_name}   {info.m_phone}  {info.m_city}\n";
                str += "--------------------------------------\n";
            }
        }

        m_txtResult.text = str;
    }

    string GetDefaultStr()
    {
        string str = "---------------------------------------\n";
        str += "순번 이름   전화      도시\n";
        str += "---------------------------------------\n";
        return str;
    }

    void OnClicked_Ok()
    {
        PrintResult();
    }

    void PrintResult()
    {
        m_infos = m_infos.OrderBy(s => s.m_name).ToList();

        string str = GetDefaultStr();

        for (int i = 0; i < m_infos.Count; i++)
        {
            Info info = m_infos[i];
            str += $"{i + 1}   {info.m_name}   {info.m_phone}  {info.m_city}\n";
            str += "--------------------------------------\n";
        }

        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        m_infos.Clear();
        ClearInput();
        m_txtResult.text = "초기화";
    }

    void OnClicked_Save()
    {
        SaveFile();
    }

    void SaveFile()
    {
        StreamWriter sw = new StreamWriter("Test018.txt");

        sw.WriteLine(m_infos.Count);

        for (int i = 0; i < m_infos.Count; i++)
        {
            Info info = m_infos[i];
            sw.WriteLine(info.m_name);
            sw.WriteLine(info.m_phone);
            sw.WriteLine(info.m_city);
        }

        sw.Close();
    }

    void OnClicked_Load()
    {
        LoadFile();
    }

    void LoadFile()
    {
        m_infos.Clear();

        StreamReader sr = new StreamReader("Test018.txt");

        int count = int.Parse(sr.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            string phone = sr.ReadLine();
            string city = sr.ReadLine();

            Info info = new Info(name, phone, city);
            m_infos.Add(info);
        }

        sr.Close();

        PrintResult();
    }

    void ClearInput()
    {
        m_inputName.text = string.Empty;
        m_inputPhone.text = string.Empty;
        m_inputCity.text = string.Empty;
        m_inputSearch.text = string.Empty;
    }

    bool CheckInput()
    {
        if(m_inputName.text == "" || m_inputPhone.text == "" || m_inputCity.text == "")
        {
            m_txtResult.text = "값을 입력해주세요.";
            return true;
        }

        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Student
{
    public string m_id = "";
    public string m_name = "";
    public int m_kor = 0;
    public int m_eng = 0;
    public int m_math = 0;

    public int Total
    {
        get
        {
            return m_kor + m_eng + m_math;
        }
    }
    public float Average
    {
        get
        {
            return (float)Total / 3;
        }
    }

    public Student(string id, string name, int kor, int eng, int math)
    {
        m_id = id;
        m_name = name;
        m_kor = kor;
        m_eng = eng;
        m_math = math;
    }
}

public class Test017_1Dlg : MonoBehaviour
{
    [SerializeField] InputField m_inputId = null;
    [SerializeField] InputField m_inputName = null;
    [SerializeField] InputField m_inputKor = null;
    [SerializeField] InputField m_inputEng = null;
    [SerializeField] InputField m_inputMath = null;
    [Space]
    [Header("버튼")]
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnEdit = null;
    [SerializeField] Button m_btnDelete = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnClear = null;
    [Space]
    [SerializeField] ScrollRect m_scrResult = null;
    [SerializeField] GameObject m_preItembox = null;
    
    List<Student> m_students = new List<Student>();
    List<ItemBox> m_items = new List<ItemBox>();

    ItemBox m_curItem = null;

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnEdit.onClick.AddListener(OnClicked_Edit);
        m_btnDelete.onClick.AddListener(OnClicked_Delete);
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Add()
    {
        if (CheckInput())
            return;

        Student stu = GetStudent();
        m_students.Add(stu);

        PrintScroll();

        ClearInput();
    }

    Student GetStudent()
    {
        string id = m_inputId.text;
        string name = m_inputName.text;
        int kor = int.Parse(m_inputKor.text);
        int eng = int.Parse(m_inputEng.text);
        int math = int.Parse(m_inputMath.text);

        Student stu = new Student(id, name, kor, eng, math);

        return stu;
    }

    void AddItemBox(Student stu)
    {
        GameObject go = Instantiate(m_preItembox, m_scrResult.content);

        ItemBox item = go.GetComponent<ItemBox>();
        item.Init(stu);
        item.GetComponent<Button>().onClick.AddListener(() => OnClicked_Item(item));

        m_items.Add(item);
    }

    void PrintScroll()
    {
        m_students.Sort((a, b) => a.Total < b.Total ? 1 : -1);
        m_items.Clear();

        ClearScroll();

        for (int i = 0; i < m_students.Count; i++)
        {
            Student student = m_students[i];
            AddItemBox(student);
        }
    }

    void OnClicked_Item(ItemBox item)
    {
        Student stu = item.m_curstudent;

        m_inputId.text = stu.m_id;
        m_inputName.text = stu.m_name;
        m_inputKor.text = $"{stu.m_kor}";
        m_inputEng.text = $"{stu.m_eng}";
        m_inputMath.text = $"{stu.m_math}";

        for (int i = 0; i < m_items.Count; i++)
        {
            m_items[i].GetComponent<Image>().color = Color.white;
        }
        item.GetComponent<Image>().color = Color.green;

        m_curItem = item;
    }

    void OnClicked_Edit()
    {
        if (CheckNull())
            return;

        if (CheckInput())
            return;

        Student stu = GetStudent();
        m_curItem.Init(stu);

        for (int i = 0; i < m_items.Count; i++)
        {
            if (m_items[i].m_curstudent.m_id == m_curItem.m_curstudent.m_id)
            {
                m_students[i] = m_items[i].m_curstudent;
                break;
            }
        }

        PrintScroll();
    }

    void OnClicked_Delete()
    {
        if (CheckNull())
            return;

        for (int i = 0; i < m_items.Count; i++)
        {
            if(m_items[i].m_curstudent.m_id == m_curItem.m_curstudent.m_id)
            {
                Destroy(m_items[i].gameObject);
                m_items.RemoveAt(i);
                m_students.RemoveAt(i);
                break;
            }
        }

        ClearInput();
    }

    void OnClicked_Save()
    {
        SaveFile();
    }

    void SaveFile()
    {
        StreamWriter sw = new StreamWriter("Test017_1.txt");
        sw.WriteLine(m_students.Count);

        for (int i = 0; i < m_students.Count; i++)
        {
            sw.WriteLine(m_students[i].m_id);
            sw.WriteLine(m_students[i].m_name);
            sw.WriteLine(m_students[i].m_kor);
            sw.WriteLine(m_students[i].m_eng);
            sw.WriteLine(m_students[i].m_math);
        }

        sw.Close();
    }

    void OnClicked_Load()
    {
        LoadFile();
    }

    void LoadFile()
    {
        m_students.Clear();
        m_items.Clear();

        StreamReader sr = new StreamReader("Test017_1.txt");
        int count = int.Parse(sr.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string id = sr.ReadLine();
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());

            Student stu = new Student(id, name, kor, eng, math);
            m_students.Add(stu);
        }

        PrintScroll();

        sr.Close();
    }

    void OnClicked_Clear()
    {
        m_items.Clear();
        m_students.Clear();
        ClearInput();
        ClearScroll();
    }

    void ClearScroll()
    {
        foreach (Transform item in m_scrResult.content)
        {
            Destroy(item.gameObject);
        }
    }

    void ClearInput()
    {
        m_inputId.text = string.Empty;
        m_inputName.text = string.Empty;
        m_inputKor.text = string.Empty;
        m_inputEng.text = string.Empty;
        m_inputMath.text = string.Empty;
    }

    bool CheckInput()
    {
        if (m_inputId.text == "" || m_inputName.text == "" || m_inputKor.text == "" || m_inputEng.text == "" || m_inputMath.text == "")
        {
            Debug.Log("값을 입력해주세요.");
            return true;
        }

        int kor = int.Parse(m_inputKor.text);
        int eng = int.Parse(m_inputEng.text);
        int math = int.Parse(m_inputMath.text);

        if(kor < 0 || kor > 100 || eng < 0 || eng > 100 || math < 0 || math > 100)
        {
            Debug.Log("값이 범위를 벗어 났습니다.");
            return true;
        }

        return false;
    }

    bool CheckNull()
    {
        if (m_curItem == null)
        {
            Debug.Log("선택된 것이 없습니다.");
            return true;
        }

        return false;
    }
}

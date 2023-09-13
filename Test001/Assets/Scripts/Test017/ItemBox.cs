using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    [SerializeField] Text m_txtId = null;
    [SerializeField] Text m_txtName = null;
    [SerializeField] Text m_txtKor = null;
    [SerializeField] Text m_txtEng = null;
    [SerializeField] Text m_txtMath = null;
    [SerializeField] Text m_txtTotal = null;
    [SerializeField] Text m_txtAverage = null;
    public Student m_curstudent;

    public int Tot
    {
        get
        {
            return m_curstudent.m_kor + m_curstudent.m_eng + m_curstudent.m_math;
        }
    }

    public void Init(Student stu)
    {
        m_curstudent = stu;

        m_txtId.text = stu.m_id;
        m_txtName.text = stu.m_name;
        m_txtKor.text = $"{stu.m_kor}";
        m_txtEng.text = $"{stu.m_eng}";
        m_txtMath.text = $"{stu.m_math}";
        m_txtTotal.text = $"{stu.Total}";
        m_txtAverage.text = string.Format("{0:0.00}", stu.Average);
    }
}

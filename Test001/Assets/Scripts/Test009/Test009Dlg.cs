using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test009Dlg : MonoBehaviour
{
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
        string str = string.Empty;

        Actor master = new Actor(5000, 100);
        str += $"[�⺻ HP={master.hp}, Attack={master.attack}]\n";
        str += $"Master HP = {master.hp}\n";

        str += "[������ 50 ����]\n";
        master.SetDamage(50);
        str += $"Master HP = {master.hp}\n";
        str += "-----------------------------------------\n";

        Actor enemy = new Actor(2000, 200);
        str += $"[�� HP={enemy.hp}, Attack={enemy.attack} ���� ����]\n";
        str += $"Enemy HP = {enemy.hp}\n";
        str += "[���� �����Ϳ��� ���� ����]\n";
        enemy.SetDamage(100);
        str += $"Enemy HP = {enemy.hp}\n";
        str += "-----------------------------------------\n";

        str += $"[�����Ͱ� HP 100��ŭ ������ ��]\n";
        master.Heal(100);
        str += $"Master HP = {master.hp}\n";
        str += $"[���� HP 200��ŭ ������ ��]\n";
        enemy.Heal(200);
        str += $"Enemy HP = {enemy.hp}\n";
        str += "-----------------------------------------\n";

        result.text = str;

    }

    void OnClicked_Clear()
    {
        result.text = "�ʱ�ȭ";
    }
}

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
        str += $"[기본 HP={master.hp}, Attack={master.attack}]\n";
        str += $"Master HP = {master.hp}\n";

        str += "[데미지 50 생김]\n";
        master.SetDamage(50);
        str += $"Master HP = {master.hp}\n";
        str += "-----------------------------------------\n";

        Actor enemy = new Actor(2000, 200);
        str += $"[적 HP={enemy.hp}, Attack={enemy.attack} 으로 설정]\n";
        str += $"Enemy HP = {enemy.hp}\n";
        str += "[적이 마스터에게 공격 당함]\n";
        enemy.SetDamage(100);
        str += $"Enemy HP = {enemy.hp}\n";
        str += "-----------------------------------------\n";

        str += $"[마스터가 HP 100만큼 힐링이 됨]\n";
        master.Heal(100);
        str += $"Master HP = {master.hp}\n";
        str += $"[적이 HP 200만큼 힐링이 됨]\n";
        enemy.Heal(200);
        str += $"Enemy HP = {enemy.hp}\n";
        str += "-----------------------------------------\n";

        result.text = str;

    }

    void OnClicked_Clear()
    {
        result.text = "초기화";
    }
}

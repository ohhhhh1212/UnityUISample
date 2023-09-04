using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster
{
    public string name = "";
    public int hp = 0;

    public Monster(string n, int h)
    {
        name = n;
        hp = h;
    }

    public void SetDamage(int d)
    {
        if (hp - d <= 0)
            hp = 0;
        else
            hp -= d;
    }
}

public class Test011Dlg : MonoBehaviour
{
    [SerializeField] InputField input_name;
    [SerializeField] InputField input_hp;
    [SerializeField] Text txt_chogi;
    [SerializeField] Text txt_result;
    [SerializeField] Button btn_add;
    [SerializeField] Button btn_ok;
    [SerializeField] Button btn_clear;

    List<Monster> monsters = new List<Monster>();

    void Start()
    {
        Init();
    } 

    void Init()
    {
        btn_add.onClick.AddListener(OnClicked_Add);
        btn_ok.onClick.AddListener(OnClicked_Ok);
        btn_clear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Add()
    {
        string name = input_name.text;
        int hp = int.Parse(input_hp.text);

        if(hp < 0 || hp > 100)
        {
            txt_result.text = "체력이 범위를 벗어났습니다.";
            return;
        }

        Monster monster = new Monster(name, hp);
        monsters.Add(monster);

        string str = "";
        for (int i = 0; i < monsters.Count; i++)
        {
            str += $"({monsters[i].name}:{monsters[i].hp}), ";
        }
        txt_chogi.text = str;

        input_name.text = string.Empty;
        input_hp.text = string.Empty;
    }

    void OnClicked_Ok()
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            monsters[i].SetDamage(80);
        }

        string str = "";
        for (int i = 0; i < monsters.Count; i++)
        {
            str += $"{i + 1} Name = {monsters[i].name}, HP={monsters[i].hp}\n";
        }

        txt_result.text = str;
    }

    void OnClicked_Clear()
    {
        txt_chogi.text = "초기값";
        txt_result.text = "초기화";
        input_name.text = string.Empty;
        input_hp.text = string.Empty;
        monsters.Clear();
    }

}

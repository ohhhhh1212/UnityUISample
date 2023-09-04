using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal
{
    public string name = "";
    public int weight = 0;

    public Animal(string n, int w)
    {
        name = n;
        weight = w;
    }
}

public class Test010Dlg : MonoBehaviour
{
    [SerializeField] InputField input_name = null;
    [SerializeField] InputField input_weight = null;
    [SerializeField] Text result = null;
    [SerializeField] Button btn_Ok = null;
    [SerializeField] Button btn_Clear = null;
    [SerializeField] Button btn_Add = null;

    List<Animal> animals = new List<Animal>();

    void Start()
    {
        Init();
    }

    void Init()
    {
        btn_Ok.onClick.AddListener(OnClicked_OK);
        btn_Clear.onClick.AddListener(OnClicked_Clear);
        btn_Add.onClick.AddListener(OnClicked_Add);
    }

    void OnClicked_OK()
    { 
        string str = "�Էµ� ���� �����ϴ�.";

        if(animals.Count == 2)
        {
            str = $"{animals[0].name}��(��) {animals[1].name}�� �������� ���� {animals[0].weight + animals[1].weight}kg�Դϴ�.";
        }
        else if(animals.Count == 1)
        {
            str = $"{animals[0].name}�� �����Դ� {animals[0].weight}kg�Դϴ�.";
        }

        result.text = str;
    }

    void OnClicked_Clear()
    {
        animals.Clear();
        result.text = "�ʱ�ȭ";
        input_name.text = string.Empty;
        input_weight.text = string.Empty;
    }

    void OnClicked_Add()
    {
        if (animals.Count >= 2)
        {
            result.text = "2�� ������ �Է°���";
            return;
        }

        if(input_name.text == "" || input_weight.text == "")
        {
            result.text = "���� �� �� �� �Է����ּ���.";
            return;
        }

        string name = input_name.text;
        int weight = int.Parse(input_weight.text);

        if (weight > 2000 || weight < 0)
        {
            result.text = "�����԰� ������ ���� �����ϴ�.";
            return;
        }

        Animal animal = new Animal(name, weight);
        animals.Add(animal);

        input_name.text = string.Empty;
        input_weight.text = string.Empty;
    }
}

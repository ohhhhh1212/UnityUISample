using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    public int hp = 0;
    public int attack = 0;


    public void SetDamage(int damage)
    {
        hp -= damage;
    }
}

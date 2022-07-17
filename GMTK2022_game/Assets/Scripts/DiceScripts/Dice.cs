using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public int MaxHealth;
    public int CurrentHealth;
    public int Attack;
    public Sprite image;

    public virtual void TakeDamage(int amount, bool isPlayer)
    {

    }

    public virtual void Setup()
    {

    }

}

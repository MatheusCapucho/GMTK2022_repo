using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Dice", menuName = "Dice")]
public class DiceComponent : ScriptableObject
{

    public int MaxHealth;
    public int CurrentHealth;
    public int attack;
    public Sprite image;

}

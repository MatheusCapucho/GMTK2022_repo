using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Dice", menuName = "Dice")]
public class DiceComponent : ScriptableObject
{

    public int MaxHealth = 4;
    public int attack = 4;
    public Sprite image;

}

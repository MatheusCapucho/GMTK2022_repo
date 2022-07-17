using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class CardComponent : ScriptableObject
{

    public string Name;
    public string Description;
    public Sprite Image;
    public int DamageMultiplier = 1;
    public int HealthMultiplier = 1;
    public int AddBaseDamage;
    public int AddBaseHealth;
    public int index;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class CardComponent : ScriptableObject
{

    public string Name;
    public string Description;
    public Sprite Image;
    public int DamageMultiplier = 0;
    public int HealthMultiplier = 0;
    public int AddBaseDamage = 0;
    public int AddBaseHealth = 0;

}

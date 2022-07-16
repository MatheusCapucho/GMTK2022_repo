using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class CardComponent : ScriptableObject
{
    public enum CardType
    {
        ONETIME, CONTINOUS
    }

    public string Name;
    public string Description;
    public Sprite Image;
    public int DamageMultiplier = 0;


}

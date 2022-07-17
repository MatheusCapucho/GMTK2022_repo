using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D6Script : Dice
{
    private void Start()
    {
        Setup();
    }
    private void OnEnable()
    {
        Setup();
    }
    public override void Setup()
    {
        MaxHealth = 6;
        CurrentHealth = 6;
        Attack = 6;

    }
    public override void TakeDamage(int amount, bool isPlayer)
    {
        Debug.Log("dmg amount " + amount);
        CurrentHealth -= amount;
        Debug.Log(gameObject.name + " Current Health: " + CurrentHealth);
        if (CurrentHealth <= 0 && isPlayer)
        {
            GameManager.Instance.UpdateBattleState(GameManager.BattleState.LOST);
        }
        else if (CurrentHealth <= 0 && !isPlayer)
        {
            GameManager.Instance.UpdateBattleState(GameManager.BattleState.WIN);
        }
        else
        {
            GameManager.Instance.UpdateBattleState(GameManager.BattleState.PLAYERTURN);
        }
    }
}

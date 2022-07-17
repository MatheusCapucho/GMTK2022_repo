using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D4Script : Dice
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
        MaxHealth = 4;
        CurrentHealth = 4;
        Attack = 4;

    }
    public override void TakeDamage(int amount, bool isPlayer)
    {
        CurrentHealth -= amount;
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

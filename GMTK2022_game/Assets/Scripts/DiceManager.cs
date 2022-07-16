using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private DiceComponent diceComponent;

    private int maxHealth;
    public int CurrentHealth { get; private set; }
    public int BaseDamage { get; private set; }

    private void Start()
    {
        maxHealth = diceComponent.MaxHealth;
        CurrentHealth = maxHealth;
        BaseDamage = diceComponent.attack;
    }
    


    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        Debug.Log(gameObject.name + " " + CurrentHealth);
        if (CurrentHealth <= 0)
        {
            if (GameManager.Instance.currentState == GameManager.BattleState.PLAYERTURN)
                GameManager.Instance.UpdateBattleState(GameManager.BattleState.WIN);
            else
                GameManager.Instance.UpdateBattleState(GameManager.BattleState.LOST);
        } else
        {
            if (GameManager.Instance.currentState == GameManager.BattleState.PLAYERTURN)
                GameManager.Instance.UpdateBattleState(GameManager.BattleState.ENEMYTURN);
            else
                GameManager.Instance.UpdateBattleState(GameManager.BattleState.PLAYERTURN);
        }
    }


}
